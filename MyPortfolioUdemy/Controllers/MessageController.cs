using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class MessageController : Controller
    {
        private readonly MyPortfolioContext _context;

        public MessageController(MyPortfolioContext context)
        {
            _context = context;
        }
        public ActionResult Inbox()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }
        [HttpGet]
        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }

        public IActionResult GetMessageDetails(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                return View(value);
            }
            return NotFound();
        }

    }
}

