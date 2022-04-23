using FlexAccounting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexAccounting.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {

        [HttpGet("list")]
        public IActionResult GetList() 
        {
            var applist = getApplicationList();

            return Ok(applist);
        }


        [HttpGet("/{Id}")]
        public IActionResult Get([FromRoute] int Id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ApplicationRequest request)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ApplicationRequest request)
        {
            return Ok();
        }

        private List<ApplicationRequest> getApplicationList()
        {

            var list = new List<ApplicationRequest>();

            list.Add(new ApplicationRequest { Id = 1, Name = "Richard", CreatedBy = "System" });
            list.Add(new ApplicationRequest { Id = 1, Name = "Jphn", CreatedBy = "Jin" });
            list.Add(new ApplicationRequest { Id = 1, Name = "Chima", CreatedBy = "Ham" });


            return list;
        }
    }
}
