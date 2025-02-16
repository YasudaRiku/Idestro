using Idestro.Server.Data;
using Idestro.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idestro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobMstController : ControllerBase
    {
        private readonly AppDbContext context;

        public JobMstController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobMst>>> ListAsync()
        {
            var jobMst = await context.JobMst.Where(x=>x.Status==0)
                                             .OrderByDescending(x => x.UploadDtm)
                                             .ToListAsync();
            return Ok(jobMst);
        }


    }
}
