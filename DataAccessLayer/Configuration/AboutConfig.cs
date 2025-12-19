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
    public class AboutConfig : EntityTypeConfiguration<About>
    {
        public AboutConfig()
        {
            HasKey(x => x.AboutID);
            Property(x => x.AboutID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NameSurname).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.Job).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.ShortDescription).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.LongDescription).HasColumnType("varchar");
            Property(x => x.Image).HasColumnType("varchar").HasMaxLength(500);
        }
    }
}
