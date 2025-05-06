using Microsoft.AspNetCore.Mvc;
using MyPortolioUdemy.DAL.Context;

namespace MyPortolioUdemy.Controllers
{
    public class MessageController : Controller
    {
        private readonly MyPortfolioContext _context;

        public MessageController(MyPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult Inbox()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
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
        public IActionResult MessageDetail(int id)
        {
            var value = _context.Messages.Find(id);
            return View(value);
        }
    }
}
