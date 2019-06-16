using System;

namespace Minotaur.CommonParts.Types
{
    public abstract class BaseEntity : IIdentifiable
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }

        public BaseEntity(Guid id, DateTime createdDate, DateTime updatedDate)
        {
            Id = id;
            CreatedDate = createdDate;
            SetUpdatedDate();
        }

        protected virtual void SetUpdatedDate()
        {
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
