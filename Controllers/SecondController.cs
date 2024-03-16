using hw_attributes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hw_attributes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondController : ControllerBase
    {
        private readonly IService5 service5;
        public SecondController(IService5 service5)
        {
            this.service5 = service5;
        }

        [HttpGet]
        public ActionResult<String> Get()
        {
            return Ok(this.service5.GetWork());
        }
    }
}
