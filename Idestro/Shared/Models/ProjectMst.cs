using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idestro.Shared.Models
{
    public class ProjectMst
    {
        [Key]
        [StringLength(50)]
        public string ProjectDesc { get; set; }
        [StringLength(255)]
        public string? Comment { get; set; }
        public int Status { get; set; }
        public DateTime? UploadDtm { get; set; }
        [StringLength(255)]
        public string? UploadUsr { get; set; }

        public ProjectMst(string projectDesc, string? comment, int status, DateTime? uploadDtm, string? uploadUsr)
        {
            ProjectDesc = projectDesc;
            Comment = comment;
            Status = status;
            UploadDtm = uploadDtm;
            UploadUsr = uploadUsr;
        }
    }
}
