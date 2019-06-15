using System;

namespace Minotaur.CommonParts.Mvc
{
    public class ServiceId
    {
        private static readonly string UniqueId = $"{Guid.NewGuid():N}";

        public string Id => UniqueId;
    }
}