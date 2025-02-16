using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idestro.Shared.Models
{
    public class JobMst
    {
        [StringLength(50)]
        public string ProjectDesc { get; set; }
        [StringLength(8)]
        public string JobDesc { get; set; }
        public int Status { get; set; }
        public DateTime? UploadDtm { get; set; }
        [StringLength(255)]
        public string? UploadUsr { get; set; }

        public JobMst(string projectDesc, string jobDesc, int status, DateTime? uploadDtm, string? uploadUsr)
        {
            ProjectDesc = projectDesc;
            JobDesc = jobDesc;
            Status = status;
            UploadDtm = uploadDtm;
            UploadUsr = uploadUsr;
        }


    }
}
