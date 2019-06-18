using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;

namespace Minotaur.Todo.Queries
{
    public class BrowseDoneTodosForAllUsers : PagedQueryBase, IQuery<PagedResult<TodoItemDto>>
    {
    }
}