using Minotaur.CommonParts.Types;
using System;

namespace Minotaur.Todo.Domain
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsDone { get; private set; }
        public Guid UserId { get; private set; }

        public TodoItem(Guid id, Guid userId, string description, string title, bool isDone) : base(id)
        {
            SetTitle(title);
            SetUserId(userId);
            SetDescription(description);
            SetIsDone(isDone);
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new MinotaurException("empty_todo_title",
                    "Title cannot be empty.");
            }

            Title = title.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }

        public void SetIsDone(bool isDone)
        {
            IsDone = isDone;
            SetUpdatedDate();
        }
        
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw  new MinotaurException("empty_todo_description",
                    "Todo description cannot be empty.");
            }

            Description = description;
            SetUpdatedDate();
        }

        public void SetUserId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new MinotaurException("empty_userId",
                "UserId cannot be empty");
            }

            UserId = id;
            SetUpdatedDate();
        }
    }
}
