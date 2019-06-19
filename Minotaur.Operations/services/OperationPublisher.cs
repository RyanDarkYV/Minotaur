﻿using System.Threading.Tasks;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.Operations.Messages.Operations.Events;

namespace Minotaur.Operations.Services
{
    public class OperationPublisher : IOperationPublisher
    {
        private readonly IBusPublisher _busPublisher;

        public OperationPublisher(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        public async Task PendingAsync(ICorrelationContext context) =>
            await _busPublisher.PublishAsync(new OperationPending(context.Id, context.UserId, context.Name, context.Resource), context);

        public async Task CompleteAsync(ICorrelationContext context)
            => await _busPublisher.PublishAsync(new OperationCompleted(context.Id,
                context.UserId, context.Name, context.Resource), context);

        public async Task RejectAsync(ICorrelationContext context, string code, string message)
            => await _busPublisher.PublishAsync(new OperationRejected(context.Id,
                context.UserId, context.Name, context.Resource, code, message), context);
    }
}