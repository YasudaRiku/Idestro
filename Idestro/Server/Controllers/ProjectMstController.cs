using Idestro.Server.Data;
using Idestro.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idestro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMstController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProjectMstController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectMst>>> ListAsync()
        {
            var projectMst = await context.ProjectMst.Where(x => x.Status == 0)
                                                     .OrderByDescending(x => x.UploadDtm)
                                                     .ToListAsync();
            return Ok(projectMst);
        }


    }
}
