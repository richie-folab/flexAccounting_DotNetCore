using FlexAccounting.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlexAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {

        private FlexAccountingDbContext _dbContext;

        public ApplicationsController(FlexAccountingDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("list")]
        public IActionResult GetAll()
        {
            try
            {

                var applications = _dbContext.Applications.ToList()
                                            .Select(p => new { p.Id, p.Name, p.Status });

                if (applications.Count() == 0) return NotFound();

                return Ok(applications);

            }
            catch (Exception)
            {

                return BadRequest("An error occured");
            }

        }

    }
}
