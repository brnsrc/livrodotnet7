﻿using System.Diagnostics; //Activity
using Microsoft.AspNetCore.Mvc; //Controller, IActionResult
using Northwind.Mvc.Models; //ErrorViewModel
using Microsoft.AspNetCore.Authorization;
using Packt.Shared;
using Northwind.mvc.Models; //NorthwindContext
using Microsoft.EntityFrameworkCore;

namespace Northwind.Mvc.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext db;

    private readonly IHttpClientFactory clientFactory;
    public HomeController(ILogger<HomeController> logger, 
        NorthwindContext injectedContext, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        db = injectedContext;
        clientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Customers(string country)
    {
        string uri;
        if (string.IsNullOrEmpty(country))
        {
            ViewData["Title"] = "All Customers Worldwide";
            uri = "api/customers";
        }
        else
        {
            ViewData["Title"] = $"Customers in {country}";
            uri = $"api/customers/?country={country}";
        }
        HttpClient client = clientFactory.CreateClient(name: "Northwind.WebApi");
        HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
        HttpResponseMessage response = await client.SendAsync(request);
        IEnumerable<Customer>? model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
        
        return View(model);
    }

    [ResponseCache(Duration = 10 /* seconds*/, 
        Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index()
    {
        _logger.LogError("This is a serious error (not really!)");
        _logger.LogWarning("This is your first waring!");
        _logger.LogWarning("Second warning!");
        _logger.LogInformation("I am in hte Index method of the HomeController");

        HomeIndexViewModel model = new (
            VisitorCount: Random.Shared.Next(0, 1001),
            Categories: db.Categories.ToList(),
            Products: await db.Products.ToListAsync()
        );

        try
        {
            HttpClient client = clientFactory.CreateClient(name: "Minimal.WebApi");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: "weatherforecast");
            HttpResponseMessage response = await client.SendAsync(request);
            ViewData["weather"] = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
        }
        catch (System.Exception ex)
        {
            _logger.LogWarning($"The Minimal.WebApi service is not responding. Exception: {ex.Message}");
            ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
        }

        return View(model); //pass model to view
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

    public async Task<IActionResult> ProductDetail(int? id){
        if (!id.HasValue){
            return BadRequest(
                "You must pass a product ID in the route,"+ 
                "for example,/Home/ProductDetail/21");
        }
        Product? model = await db.Products.SingleOrDefaultAsync(
            p => p.ProductId == id);
        if(model is null){
            return NotFound($"ProductId {id} not found.");
        }
        return View(model); //pass model to view and then return result
    }

    public async Task<IActionResult> Category(int? id){
        if (!id.HasValue){
            return BadRequest(
                "You must pass a category ID in the route,"+ 
                "for example,/Home/Category/21");        
        }

        Category? model = await db.Categories.SingleOrDefaultAsync(
            c => c.CategoryId == id);

            if(model is null){
                return NotFound($"Category {id} nof found.");
            }
            return View(model);
    }




    public IActionResult ModelBinding(){
        return View(); //the page with to submit
    }

    [HttpPost]
    public ActionResult ModelBinding(Thing thing){
        HomeModelBindingViewModel model = new(
            Thing: thing, HasErrors: !ModelState.IsValid,
            ValidationErrors: ModelState.Values.
                SelectMany(state => state.Errors).
                Select(error => error.ErrorMessage)
        );
        return View(model); 
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price){
        if (!price.HasValue){
            return BadRequest("You must pass a product in the query string, " 
            +"for example, /Home/ProductsThatCostMoreThan?price=50");
        }
        IEnumerable<Product> model = db.Products.Include(p => p.Category)
            .Include(p => p.Supplier).Where(p => p.UnitPrice > price);

        if (!model.Any())
        {
            return NotFound(
                $"No products cost more than {price:C}.");
        }
        ViewData["MaxPrice"] = price.Value.ToString("C");
        return View(model); //pass model to view
    }
}
