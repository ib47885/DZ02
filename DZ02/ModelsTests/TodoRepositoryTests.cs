using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Repositories;

namespace Repositories.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }
        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }
        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }

        [TestMethod()]
        public void GetExistingItemTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            Assert.AreEqual(todoItem.Id.ToString(), repository.Get(todoItem.Id).Id.ToString());
        }

        [TestMethod()]
        public void GetNonExistingItemTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            Assert.IsNull(repository.Get(new Guid()));
        }

        [TestMethod()]
        public void GetActiveReturnsEmptyListTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.MarkAsCompleted(todoItem.Id);
            Assert.AreEqual(0,repository.GetActive().Count());
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.MarkAsCompleted(todoItem.Id);            
            Assert.AreEqual(1, repository.GetActive().Count());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.MarkAsCompleted(todoItem.Id);
            Assert.AreEqual(2, repository.GetAll().Count());
        }

        [TestMethod()]
        public void GetAllReturnsEmptyListTest()
        {
            ITodoRepository repository = new TodoRepository();
            Assert.AreEqual(0, repository.GetAll().Count());
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            repository.MarkAsCompleted(todoItem.Id);
            Assert.AreEqual(1, repository.GetCompleted().Count());
        }

        [TestMethod()]
        public void GetCompletedReturnsEmptyListTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            Assert.AreEqual(0, repository.GetCompleted().Count());
        }

  
        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            Assert.IsTrue(repository.MarkAsCompleted(todoItem.Id)==true);
            Assert.IsFalse(repository.MarkAsCompleted(new Guid())==true);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            Assert.IsTrue(repository.Remove(todoItem.Id));
            Assert.IsFalse(repository.Remove(new Guid()));
        }

    }
}