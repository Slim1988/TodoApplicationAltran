using AltranApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranApplication.Services
{
    public class TodoServices
    {
        // liste todo
        public List<Todo> TodoListByUser(int userId)
        {
            List<Todo> todos = new List<Todo>();
            using (TodosDBEntities db = new TodosDBEntities())
            {
                //todos = db.Todo.Where(t => t.UserId == userId).OrderBy(t => new { t.State, t.TodoId }).ToList();
                todos = db.Todo.Where(t => t.UserId == userId)
                               .OrderBy(t => t.State)
                               .ThenByDescending(t => t.TodoId).ToList();

            }

            return todos;
        }

        //Delete 

        public void DeleteTodoByUser(int id)
        {
            using (TodosDBEntities db = new TodosDBEntities())
            {
                Todo todo = db.Todo.Where(t => t.TodoId == id).FirstOrDefault();
                db.Todo.Remove(todo);
                db.SaveChanges();
            }
        }

        public Todo FindTodoById(int Id)
        {
            Todo todo;
            using (TodosDBEntities db = new TodosDBEntities())
            {
                //todo = db.Todo.Where(t => t.TodoId == Id).FirstOrDefault();
                todo = db.Todo.Find(Id);
            }

            return todo;
        }

        public void UpdateTodoByUser(Todo todo, int userId)
        {
            using (TodosDBEntities db = new TodosDBEntities())
            {
                db.Entry(todo).State = System.Data.EntityState.Modified;
                todo.UserId = userId;
                db.SaveChanges();
            }
        }
        public void CreateTodoByUser(Todo todo,int userId)
        {
            using (TodosDBEntities db = new TodosDBEntities())
            {
                todo.State = false;
                todo.UserId = userId;
                db.Todo.Add(todo);
                db.SaveChanges();
            }

        }
    }
}