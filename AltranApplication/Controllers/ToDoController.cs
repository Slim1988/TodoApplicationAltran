using AltranApplication.Models;
using AltranApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltranApplication.Controllers
{
    public class ToDoController : Controller
    {
        private readonly TodoServices _services = new TodoServices();
        

        // GET: ToDo
        public ActionResult Index()
        {
            
            var todos = _services.TodoListByUser((int)Session["UserId"]);
            return View(todos.ToList());
        }

        public ActionResult DeleteTodo(int id)
        {
   
            _services.DeleteTodoByUser(id);
            return RedirectToAction("Index");
        }


        public ActionResult DetailsTodo(int Id)
        {
            var todo = _services.FindTodoById(Id);
            return View(todo);
        }

        // Modify Todo

        [HttpGet]
        public ActionResult EditTodo(int Id)
        {
            var todo = _services.FindTodoById(Id);
            return View(todo);
        }

        [HttpPost]
        public ActionResult EditTodo(Todo todo)
        {
            if (ModelState.IsValid)
            {            
                _services.UpdateTodoByUser(todo, (int)Session["UserId"]);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditTodo");
            }
        }

        //Create a new Todo

        [HttpGet]
        public ActionResult CreateTodo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTodo(Todo todo)
        {

            if (ModelState.IsValid)
            {
                _services.CreateTodoByUser(todo, (int)Session["UserId"]);
                return RedirectToAction("Index");
            }
            else { return View("CreateTodo"); }

        }


        //Logout

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}