
using Backend.Services;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            var jobID = BackgroundJob.Enqueue<IBackendJobService>(x => x.SendEmail());
            
            return "Hello World";
        }
        
        
        [HttpGet("/authonly")]
        [Authorize]
        public ActionResult<string> GetAuth()
        {
            return "Hello World";
        }
    }
}