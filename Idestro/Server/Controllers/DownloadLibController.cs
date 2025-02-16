using Idestro.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Text.Json;


namespace Idestro.Server.Controllers
{
    public class DownloadLibController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        public DownloadLibController(IWebHostEnvironment environment, ILogger<DownloadLibController> logger)
        {
            this.environment = environment;
            _logger = logger;
        }

        private readonly ILogger<DownloadLibController> _logger;

        [Route("api/download/file")]
        public async Task<IActionResult> DownloadDocument(IFormFile file)
        {
            //とりあえずつかっていない
            try
            {
                // ここでログ出力させる
                _logger.LogInformation("処理スタート！");
                
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] buffer = memoryStream.ToArray();
                    string? fileName = JsonSerializer.Deserialize<string>(Encoding.ASCII.GetString(buffer));
                    if (fileName.IsNullOrEmpty()) { throw new Exception(); }

                    string destDirectory = Path.Combine(@"D:\Idestro", "unixlib", "ProjectName", "JobName", "01");
                    string destFile = Path.Combine(destDirectory, fileName);

                    if (!System.IO.File.Exists(destFile)) { throw new Exception(); }

                    return File(System.IO.File.ReadAllBytes(destFile), "application/octet-stream", fileName);
                };

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
