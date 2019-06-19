using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minotaur.CommonParts;
using Minotaur.CommonParts.Consul;
using Minotaur.CommonParts.Dispatchers;
using Minotaur.CommonParts.Mongo;
using Minotaur.CommonParts.Mvc;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.CommonParts.Redis;
using Minotaur.Todo.Domain;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using System;
using System.Reflection;
using Minotaur.CommonParts.Jaeger;
using Minotaur.CommonParts.Swagger;

namespace Minotaur.Todo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSwaggerDocs();
            services.AddConsul();
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddRedis();
            services.AddInitializers(typeof(IMongoDbInitializer));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.AddMongoRepository<TodoItem>("TodoItem");
            builder.AddDispatchers();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<CreateTodo>(onError: (c, e) =>
                    new CreateTodoItemRejected(c.Id, e.Message, e.Code))
                .SubscribeCommand<UpdateTodo>(onError: (c, e) =>
                    new UpdateTodoItemRejected(c.Id, e.Message, e.Code))
                .SubscribeCommand<DeleteTodo>(onError: (c, e) =>
                    new DeleteTodoItemRejected(c.Id, e.Message, e.Code));

            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
                Container.Dispose();
            });

            startupInitializer.InitializeAsync();
        }
    }
}
