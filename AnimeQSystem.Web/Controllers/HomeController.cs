using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Used to add the specific background image to the biggest container
            ViewData["BodyClass"] = "background-page";

            return View();
        }

        [HttpGet]
        // Action to handle all errors
        public IActionResult Error()
        {
            int status = Response.StatusCode;

            // Get the exception details (if available)
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string exceptionMessage = exceptionDetails?.Error?.Message ?? "An unknown error occurred.";

            if (status == 400)
            {
                return View("~/Views/Errors/400.cshtml", exceptionMessage); // 400 view
            }
            else if (status == 500)
            {
                return View("~/Views/Errors/500.cshtml", exceptionMessage); // 500 view
            }
            else
            {
                return View("~/Views/Errors/404.cshtml", exceptionMessage);
            }
        }
    }
}
