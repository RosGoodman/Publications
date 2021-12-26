using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Publications.Domain.Entityes.Identity;
using Publications.MVC.ViewModels;

namespace Publications.MVC.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        UserManager<User> userManager, 
        SignInManager<User> signInManager, 
        ILogger<AccountController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    /// <summary>  </summary>
    /// <returns> html-страничка с пустой моделью. </returns>
    public IActionResult Register() => View(new RegisterUserViewModel());

    /// <summary>  </summary>
    /// <param name="viewModel"> ViewModel из web-формы. </param>
    /// <returns></returns>
    [HttpPost]  //метод реагирует только на Post запросы.
    public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout() => RedirectToAction("Index", "Home");
}
