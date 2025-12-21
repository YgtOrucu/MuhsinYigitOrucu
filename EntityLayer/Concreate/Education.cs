using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Education")]
    public class Education
    {
        public int EducationID { get; set; }
        public string HeadingName { get; set; }
        public string SubHeadingName { get; set; }
        public string SubHeadingName1 { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
    }
}
