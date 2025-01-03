using System.Diagnostics; //Activity
using Microsoft.AspNetCore.Mvc; //Controller, IActionResult
using Northwind.Mvc.Models; //ErrorViewModel
using Microsoft.AspNetCore.Authorization;
using Packt.Shared;
using Northwind.mvc.Models; //NorthwindContext

namespace Northwind.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext db;
    public HomeController(ILogger<HomeController> logger, 
        NorthwindContext injectedContext)
    {
        _logger = logger;
        db = injectedContext;
    }

    [ResponseCache(Duration = 10 /* seconds*/, 
        Location = ResponseCacheLocation.Any)]
    public IActionResult Index()
    {
        _logger.LogError("This is a serious error (not really!)");
        _logger.LogWarning("This is your first waring!");
        _logger.LogWarning("Second warning!");
        _logger.LogInformation("I am in hte Index method of the HomeController");

        HomeIndexViewModel model = new (
            VisitorCount: Random.Shared.Next(0, 1001),
            Categories: db.Categories.ToList(),
            Products: db.Products.ToList()
        );

        return View();
    }


    [Route("private")]
    [Authorize(Roles = "Administrators")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
