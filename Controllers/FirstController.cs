using hw_attributes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hw_attributes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private readonly IService1 service;
        public FirstController(IService1 service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(this.service.GetHelloWorld());
        }
    }
}
