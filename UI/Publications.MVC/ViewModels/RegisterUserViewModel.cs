using System.ComponentModel.DataAnnotations;

namespace Publications.MVC.ViewModels;

public class RegisterUserViewModel
{
    [Required]  //говорит о том, что UserName является обязательным
    [Display(Name = "Имя пользователя")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]  //тип данных
    public string Password { get; set; }

    [Required]
    [Display(Name = "Подтверждение пароля")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))] //делает валидацию по указанному св-ву (в данном случае - Password)
    public string PasswordConfirm { get; set; }
}
