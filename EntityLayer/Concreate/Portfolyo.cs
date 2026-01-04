using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Portfolyo")]
    public class Portfolyo
    {
        public int PortfolyoID { get; set; }
        public string HeadingName { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<PortfolyoImages> PortfolyoImages { get; set; }
        public string GitHubUrl { get; set; }
    }
}
