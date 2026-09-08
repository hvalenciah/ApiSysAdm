/**
 *
 * @file Home.cs
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using Microsoft.AspNetCore.Mvc;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = Configuration["OpenApiInfo:Title"] + " " + Configuration["OpenApiInfo:Version"],
                Data = new List<object>()
            });
        }
    }
}
