using System.Collections.Generic;
namespace MvxApp.Models
{
    public class TodoHolder
    {
        public static TodoHolder Current { get; } = new TodoHolder();
        public List<Todo> TodoList { get; set; } = new List<Todo>();
    }
}
