namespace Publications.MVC.infrastructure.Middleware;

///конвейер
public class TestMiddleware
{
    private readonly RequestDelegate _next;



    public TestMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        //мы начинаем анализ данных внутри context

        var next = _next(context); //вызываем слудующую часть ковейера

        //параллельно конвейеру выполняем какие-то действия

        await next;   //синхронизируемся с остальной цепочкой обработки запроса

        //выполняем алализ и постобработку данных в context
    }
}
