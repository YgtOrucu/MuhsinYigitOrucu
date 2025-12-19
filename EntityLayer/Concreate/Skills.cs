using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Skills")]
    public class Skills
    {
        public int SkillsID { get; set; }
        public string SkillsName { get; set; }
        public string SkillsPercentage { get; set; }
        public bool Status { get; set; }

    }
}
