using System;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents;

public class _StatComponentPartial : ViewComponent
{
    private readonly MyPortfolioContext _context;

    public _StatComponentPartial(MyPortfolioContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
