using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public ConcurrentBag<string> Datas { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ben Order Apiyim");
        }

        [HttpPost]
        public IActionResult Post(string data)
        {
            Datas.Add(data);

            return Ok("Order data eklendi __ " + data);
        }
    }
}
