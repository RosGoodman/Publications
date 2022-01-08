using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Publications.MVC.Controllers.API
{
    [Route("api/console")]
    [ApiController]
    public class ConsoleApiController : ControllerBase
    {
        [HttpGet("Clear")]
        public void Clear() => Console.Clear();

        [HttpGet("WriteLine/{message}")]
        public void WriteLine(string message) => Console.WriteLine(message);


        [HttpGet("throw/{message}")]
        public void Throw(string message) => throw new ApplicationException(message);
    }
}
