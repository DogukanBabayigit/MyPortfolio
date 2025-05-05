using System;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents;

public class _NavbarComponentPartial : ViewComponent
{
    private readonly MyPortfolioContext _context;

    public _NavbarComponentPartial(MyPortfolioContext context)
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
