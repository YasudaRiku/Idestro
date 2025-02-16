using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idestro.Shared.Models
{
    public class FieldMst
    {
        [StringLength(50)]
        public string ProjectDesc { get; set; }
        [StringLength(8)]
        public string JobDesc { get; set; }
        [StringLength(2)]
        public string FmtNo { get; set; }
        [StringLength(5)]
        public string FldNo { get; set; }
        public int? StartCol { get; set; }
        public int? LastCol { get; set; }
        public int? FldLen { get; set; }
        [StringLength(1)]
        public string? FldUse { get; set; }
        [StringLength(40)]
        public string IdesFldDesc { get; set; }

        public DateTime? UploadDtm { get; set; }
        [StringLength(255)]
        public string? UploadUsr { get; set; }

        public FieldMst(string projectDesc, string jobDesc, string fmtNo, string fldNo, int? startCol, int? lastCol, int? fldLen, string? fldUse, string idesFldDesc, DateTime? uploadDtm, string uploadUsr)
        {
            ProjectDesc = projectDesc;
            JobDesc = jobDesc;
            FmtNo = fmtNo;
            FldNo = fldNo;
            StartCol = startCol;
            LastCol = lastCol;
            FldLen = fldLen;
            FldUse = fldUse;
            IdesFldDesc = idesFldDesc;
            UploadDtm = uploadDtm;
            UploadUsr = uploadUsr;
        }


    }
}
