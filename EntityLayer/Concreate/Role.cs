using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleType { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}
