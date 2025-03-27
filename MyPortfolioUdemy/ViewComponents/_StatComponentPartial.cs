using System;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioUdemy.ViewComponents;

public class _StatComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
