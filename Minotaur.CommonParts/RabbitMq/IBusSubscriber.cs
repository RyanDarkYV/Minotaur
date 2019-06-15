using System;
using Minotaur.CommonParts.Messages;
using Minotaur.CommonParts.Types;

namespace Minotaur.CommonParts.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, MinotaurException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, MinotaurException, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}