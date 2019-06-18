using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;

namespace Minotaur.Todo.Queries
{
    public class BrowseNotDoneTodosForAllUsers : PagedQueryBase, IQuery<PagedResult<TodoItemDto>>
    {
        
    }
}