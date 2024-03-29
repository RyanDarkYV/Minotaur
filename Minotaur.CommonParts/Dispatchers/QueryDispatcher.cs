﻿using System.Threading.Tasks;
using Autofac;
using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.Types;

namespace Minotaur.CommonParts.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }


        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _componentContext.Resolve(handlerType);
            return await handler.HandleAsync((dynamic) query);
        }
    }
}