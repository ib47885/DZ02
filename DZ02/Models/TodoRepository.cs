using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Repositories
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly List<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(List<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new List<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >() ;
            // x ?? y -> if x is not null , expression returns x. Else y.
        }

        public TodoItem Get(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Exists(t => t.Id.Equals(todoId)))
            {
                return _inMemoryTodoDatabase.Find(t => t.Id.Equals(todoId));
         
            }
            return null;
            
        }

        public void Add(TodoItem todoItem)
        {
            if(todoItem == null)
            {
                throw new ArgumentNullException();
            }
            if (_inMemoryTodoDatabase.Exists(t => t.Id.Equals(todoItem.Id)))
            {
                throw new DuplicateTodoItemException(" duplicate id: " + todoItem.Id.ToString());

            }
            _inMemoryTodoDatabase.Add(todoItem);

        }

        public List<TodoItem> GetActive()
        {
            List<TodoItem> newList = _inMemoryTodoDatabase.Where(t => t.IsCompleted == false).ToList();
            return newList;
        }

        public List<TodoItem> GetAll()
        {
            List<TodoItem> newList = _inMemoryTodoDatabase.OrderByDescending(t => t.DateCreated).ToList();
            return newList;
        }

        public List<TodoItem> GetCompleted()
        {
            List<TodoItem> newList = _inMemoryTodoDatabase.Where(t => t.IsCompleted == true).ToList();
            return newList;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            List<TodoItem> newList = _inMemoryTodoDatabase.Where(t => filterFunction(t)==true).ToList();
            return newList;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if(_inMemoryTodoDatabase.Exists(t => t.Id.Equals(todoId)))
            {
                TodoItem newItem = _inMemoryTodoDatabase.Find(t => t.Id.Equals(todoId));
                newItem.MarkAsCompleted();
                Update(newItem);
                return true;
            }
            return false;
        }

        public bool Remove(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Exists(t => t.Id.Equals(todoId)))
            {
                _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.Find(t => t.Id.Equals(todoId)));
                return true;
            }
            return false;
        }

        public void Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Exists(t => t.Id.Equals(todoItem.Id)))
            {
                _inMemoryTodoDatabase[_inMemoryTodoDatabase.IndexOf(_inMemoryTodoDatabase.Find(t => t.Id.Equals(todoItem.Id)))] = todoItem;

            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
        }
    }
}
