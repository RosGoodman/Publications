using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Publications.MVC.ViewModels;

public class LoginViewModel
{
    [Required]  //говорит о том, что UserName является обязательным
    [Display(Name = "Имя пользователя")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]  //тип данных
    public string Password { get; set; }

    [Display(Name = "Запомнить меня")]
    public bool RememberMe { get; set; }

    /// <summary> Куда выполнять еренаправление (возвращаться). </summary>
    [HiddenInput(DisplayValue = false)]
    public string? ReturnUrl { get; set; }
}
