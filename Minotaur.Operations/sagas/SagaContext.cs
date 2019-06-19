using System;
using System.Collections.Generic;
using Chronicle;
using Minotaur.CommonParts.RabbitMq;

namespace Minotaur.Operations.Sagas
{
    public class SagaContext : ISagaContext
    {
        public Guid CorrelationId { get; }
        public string Originator { get; }

        public SagaContext(Guid correlationId, string originator) =>
            (CorrelationId, Originator) = (correlationId, originator);

        public static ISagaContext Empty => new SagaContext(Guid.Empty, string.Empty);
        public static ISagaContext FromCorrelationContext(ICorrelationContext context) => new SagaContext(context.Id, context.Resource);
    }
}