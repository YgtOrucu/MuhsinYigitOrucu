using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("About")]
    public class About
    {
        public int AboutID { get; set; }
        public string NameSurname { get; set; }
        public string Job { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
