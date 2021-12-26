using Publications.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Publications.Domain.Entityes.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllersWithViews();
services.AddDbContext<PublicationsDB>(opt => opt
    .UseNpgsql(builder.Configuration.GetConnectionString("Default")));

services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<PublicationsDB>()
    .AddDefaultTokenProviders();

services.Configure<IdentityOptions>(opt =>
{
#if DEBUG
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 3;
    opt.Password.RequiredUniqueChars = 3;
#endif

    opt.User.RequireUniqueEmail = false;
    opt.User.AllowedUserNameCharacters = "abcdifghijklmnopqrstuvwxyzABCDIFGHIJKLMNOPQRSTUVWXYZ1234567890";

    opt.Lockout.AllowedForNewUsers = false; //менять идентификатор сессии, если пользователь залогинился
    opt.Lockout.MaxFailedAccessAttempts = 10;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
});

//кофигурирование cookies
services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.Name = "Publications";

    opt.Cookie.HttpOnly = true; //передавать куки можно только по протоколу http

    opt.ExpireTimeSpan = TimeSpan.FromDays(10); //перезапрошены будут через 10 дней

    //перенаправление на контроллеры в случае необходимости выйти и войти в систему
    opt.LoginPath = "Account/Login";
    opt.LogoutPath = "Account/Logout";
    opt.AccessDeniedPath = "Account/AccessDenied";

    opt.SlidingExpiration = true;   //изменять идентификатор сессии
});

var app = builder.Build();

using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PublicationsDB>();

    await db.Database.MigrateAsync();   //Создание БД в случае ее отсутствия и приведение ее к последнему состоянию

    var id = 5;
    var some_publication = await db.Publications.FirstOrDefaultAsync(p => p.Id == id);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//подключение систеы идентити
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
