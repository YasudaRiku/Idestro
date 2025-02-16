using Idestro.Server.Data;
using Idestro.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Idestro.Server.Controllers
{
    public class MasterSettingsController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        public MasterSettingsController(IWebHostEnvironment environment, AppDbContext context, ILogger<IdestroController> logger)
        {
            this.environment = environment;
            this.context = context;
            _logger = logger;
        }

        private readonly ILogger<IdestroController> _logger;

        [HttpPost("api/register/project")]
        public async void RegisterProject([FromBody] ProjectMst pm)
        {
            try
            {
                context.Add(pm);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        [HttpPost("api/register/job")]
        public async void RegisterJob([FromBody] JobMst jm)
        {
            try
            {
                context.Add(jm);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        [Route("api/register/field")]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
            try
            {
                string[] fileNameArray = file.FileName.Split('_');
                string projectDesc = fileNameArray[0];
                string jobDesc = fileNameArray[1];
                string fmtNo = fileNameArray[2];
                string fileName = "";

                for (int i = 3; i < fileNameArray.Length; i++)
                {
                    fileName += fileNameArray[i];
                }

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var enc = Encoding.GetEncoding("shift_jis");
                    string data = enc.GetString(memoryStream.ToArray());
                    foreach (string line in data.Split("\r\n"))
                    {
                        if (line.Length != 0 && line.Substring(0, 3) != "000")
                        {
                            string fldNo = "(" + line.Substring(0, 3) + ")";

                            string idesFldDesc;
                            //①指定されたバイト数で文字を切り出す
                            string result = enc.GetString(enc.GetBytes(line), 8, 40);
                            //②指定されたバイト数+1バイトで文字を切り出す
                            string result2 = enc.GetString(enc.GetBytes(line), 8, 41);
                            //①と②の文字数を比較する
                            if (result.Length == result2.Length)
                            {
                                //同じなら①から最後の１文字を削除した文字列を返す
                                idesFldDesc = result.Remove(result.Length - 1);
                            }
                            else
                            //異なれば①をそのまま返す
                            {
                                idesFldDesc  = result;
                            }
                            idesFldDesc = idesFldDesc.Replace("^", "").Trim();
                            FieldMst fieldMst = new FieldMst(projectDesc, jobDesc, fmtNo, fldNo, null, null, null, null, idesFldDesc, DateTime.Now, "SYSTEM");
                            context.Add(fieldMst);
                            await context.SaveChangesAsync();
                        }
                    }
                };
                
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
