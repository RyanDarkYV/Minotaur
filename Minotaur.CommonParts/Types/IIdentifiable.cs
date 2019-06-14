using System;

namespace Minotaur.CommonParts.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}