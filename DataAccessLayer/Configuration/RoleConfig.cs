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
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            HasKey(x => x.RoleID);
            Property(x => x.RoleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleType).HasColumnType("varchar").HasMaxLength(15).IsRequired();
        }
    }
}
