using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configuration
{
    public class AdminConfig : EntityTypeConfiguration<Admin>
    {
        public AdminConfig()
        {
            HasKey(x => x.AdminID);
            Property(x => x.AdminID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NameSurname).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.About).HasColumnType("varchar").HasMaxLength(150);
            Property(x => x.Address).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Image).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.MailAddress).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.Password).HasColumnType("varchar").HasMaxLength(80);    
        }
    }
}
