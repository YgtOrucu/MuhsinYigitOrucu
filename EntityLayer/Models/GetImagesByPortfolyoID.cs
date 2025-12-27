using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class GetImagesByPortfolyoID
    {
        public int PortfolyoID { get; set; }
        public string HeadingName { get; set; }
        public List<string> Images { get; set; }
    }
}
