using Microsoft.AspNetCore.Mvc;

namespace CoreSTSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            return Ok(new {Id = 1, Name = ".NET CORE Web Api", Description = "Lorem ipsum sit dolor amet!"});
        }
    }
}