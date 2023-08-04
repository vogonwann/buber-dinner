using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Schedule.Me.Api.Controllers
{
 
    public class ErrorsController : ApiController
    {
        [Route("/error")]
        public IActionResult Get()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(title: exception?.Message, statusCode: 400);
        }
    }
}