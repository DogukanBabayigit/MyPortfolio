using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class StatisticController : Controller
    {
        private readonly MyPortfolioContext _context;

        public StatisticController(MyPortfolioContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            ViewBag.v1 = _context.Skills.Count();
            ViewBag.v2 = _context.Messages.Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = _context.Messages.Where(x => x.IsRead == true).Count();
            return View();
        }
    }
}
