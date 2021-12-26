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
    /// <param name="model"> ViewModel из web-формы. </param>
    /// <returns></returns>
    [HttpPost]  //метод реагирует только на Post запросы.
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {
        //если модель не корректная, то она будет отправлена обратно с указанными ошибками, чтобы пользователь мог их исправить
        if(!ModelState.IsValid) return View(model);

        var user = new User { UserName = model.UserName };
        var creation_result = await _userManager.CreateAsync(user, model.Password);

        //если все успешно, то вошли в систему
        if (creation_result.Succeeded)
        {
            //await _userManager.AddToRoleAsync(user, "User");

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        //перекидывание всех ошибк в модель, чтобы пользователь смог их увидеть
        foreach (var error in creation_result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        _logger.LogWarning("Ошибка регистрации нового пользователя {0}",
            string.Join(",", creation_result.Errors.Select(e => e.Description)));

        return View(model);
    }

    public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl});

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var login_result = await _signInManager.PasswordSignInAsync(
            model.UserName,
            model.Password,
            model.RememberMe,
            false);

        if (login_result.Succeeded)
            return LocalRedirect(model.ReturnUrl ?? "/");

        ModelState.AddModelError(String.Empty, "Ошибка ввода имени пользователя или пароля.");

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
