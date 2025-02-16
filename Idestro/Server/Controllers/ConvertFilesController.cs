using Idestro.Server.Data;
using Idestro.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idestro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertFilesController : ControllerBase
    {
        private readonly AppDbContext context;

        public ConvertFilesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConvertFile>>> ListAsync()
        {
            var convertFiles = await context.ConvertFiles.OrderByDescending(b => b.UploadDtm).ToListAsync();
            
            return Ok(convertFiles);
        }

    }
}
