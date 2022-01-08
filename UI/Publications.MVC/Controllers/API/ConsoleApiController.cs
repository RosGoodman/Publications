using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Publications.MVC.Controllers.API
{
    [ApiController, Route("api/[console]")]
    public class ConsoleApiController : ControllerBase
    {
        //[HttpGet("clear")]
        //public void Clear() => Console.Clear();

        //[HttpGet("WriteLine/{message}")]
        //public void WriteLine(string message) => Console.WriteLine(message);
    }
}
