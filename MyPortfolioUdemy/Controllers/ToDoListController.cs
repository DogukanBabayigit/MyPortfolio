using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ToDoListController(MyPortfolioContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var value = _context.ToDoLists.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateToDoList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Status = false; // Set default status to false
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteToDoList(int id)
        {
            var value = _context.ToDoLists.Find(id);
            if (value != null)
            {
                _context.ToDoLists.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateToDoList(int id)
        {
            var value = _context.ToDoLists.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = _context.ToDoLists.Find(id);
            if (value != null)
            {
                value.Status = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = _context.ToDoLists.Find(id);
            if (value != null)
            {
                value.Status = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
