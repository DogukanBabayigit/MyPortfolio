using Microsoft.AspNetCore.Mvc;
using MyPortolioUdemy.DAL.Context;

namespace MyPortolioUdemy.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		private readonly MyPortfolioContext _context;

		public _LayoutNavbarComponentPartial(MyPortfolioContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount = _context.ToDoLists.Where(x => x.Status == false).Count();
			var values = _context.ToDoLists.Where(x => x.Status == false).ToList();
			return View(values);
		}
	}
}
