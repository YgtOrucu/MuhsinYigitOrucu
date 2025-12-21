using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Experience")]
    public class Experience
    {
        public int ExperienceID { get; set; }
        public string CompanyName { get; set; }
        public string JobName { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
    }
}
