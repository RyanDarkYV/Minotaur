namespace Minotaur.CommonParts.Types
{
    //Marker for CQS
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {
    }
}