using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.Data.SqlClient;
using Idestro.Server.Data;
using Idestro.Shared.Models;

namespace Idestro.Server.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class IdestroController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        public IdestroController(IWebHostEnvironment environment, AppDbContext context, ILogger<IdestroController> logger)
        {
            this.environment = environment;
            this.context = context;
            _logger = logger;
        }

        private readonly ILogger<IdestroController> _logger;

        [Route("api/upload/file")]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
            try
            {
                string[] fileNameArray = file.FileName.Split('_');
                string projectName = fileNameArray[0];
                string jobName = fileNameArray[1];
                string fmtName = fileNameArray[2];
                string fileName = "";

                for (int i = 3; i < fileNameArray.Length; i++)
                {
                    fileName += fileNameArray[i];
                }
                //kobolファイル配置先を作成
                string destDirectory = Path.Combine(environment.ContentRootPath, "wwwroot", "kobol", projectName, jobName, fmtName);
                if (!Directory.Exists(destDirectory)) { Directory.CreateDirectory(destDirectory); }

                //unixlibsファイル配置先を作成
                string psDestDirectory = Path.Combine(environment.ContentRootPath, "wwwroot", "unixlib", projectName, jobName, fmtName);
                if (!Directory.Exists(psDestDirectory)) { Directory.CreateDirectory(psDestDirectory); }

                DateTime dt = DateTime.Now;
                
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var data2 = memoryStream.ToArray();
                    string filePath = Path.Combine(destDirectory, Path.GetFileNameWithoutExtension(fileName) + "_" + dt.ToString("yyyyMMddHHmmss") + ".txt");
                    using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(data2, 0, data2.Length);
                        fs.Close();
                    }
                };

                ConvertFile convertFile = new ConvertFile(projectName, jobName, fmtName, Path.GetFileNameWithoutExtension(fileName) + "_" + dt.ToString("yyyyMMddHHmmss") + ".txt", 0, dt, "");
                context.Add(convertFile);
                await context.SaveChangesAsync();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }
    }
}
