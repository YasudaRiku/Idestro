using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idestro.Shared.Models
{
    public class ConvertFile
    {
        [StringLength(50)]
        public string ProjectDesc { get; set; }
        [StringLength(8)]
        public string JobDesc { get; set; }
        [StringLength(2)]
        public string FmtNo { get; set; }
        [StringLength(255)]
        public string FileDesc { get; set; }
        public int Status { get; set; }
        public DateTime? UploadDtm { get; set; }
        [StringLength(255)]
        public string? UploadUsr { get; set; }

        public ConvertFile(string projectDesc, string jobDesc, string fmtNo, string fileDesc, int status, DateTime? uploadDtm, string? uploadUsr)
        {
            ProjectDesc = projectDesc;
            JobDesc = jobDesc;
            FmtNo = fmtNo;
            FileDesc = fileDesc;
            Status = status;
            UploadDtm = uploadDtm;
            UploadUsr = uploadUsr;
        }

    }
}
