using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("PortfolyoImages")]
    public class PortfolyoImages
    {
        public int PortfolyoImagesID { get; set; }
        public string Images { get; set; }
        public int PortfolyoID { get; set; }
        public Portfolyo Portfolyo { get; set; }
    }
}
