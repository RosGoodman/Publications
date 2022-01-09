

using Microsoft.AspNetCore.Mvc;
using Publications.Domain.Entities;
using Publications.Interfaces.Repositories;
using Publications.MVC.Models;
using System.Diagnostics;

namespace Publications.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Publications([FromServices] IRepository<Publication> Publications)
    {
        var publications = await Publications.GetAllAsync();

        return View(publications);
    }
}
