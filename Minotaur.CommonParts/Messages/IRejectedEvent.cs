namespace Minotaur.CommonParts.Messages
{
    public interface IRejectedEvent : IEvent
    {
         string Reason { get;  }
         string Code { get; }
    }
}