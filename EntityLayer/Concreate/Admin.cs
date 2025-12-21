using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Admin")]
    public class Admin
    {
        public int AdminID { get; set; }
        public string NameSurname { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
