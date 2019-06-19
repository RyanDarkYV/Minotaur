using System;

namespace Minotaur.Api.Queries
{
    public class BrowseTodosForUser : PagedQuery
    {
        public Guid Id {get;set;}
    }
}