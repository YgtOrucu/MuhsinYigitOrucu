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
    public class ExperienceConfig : EntityTypeConfiguration<Experience>
    {
        public ExperienceConfig()
        {
            HasKey(x => x.ExperienceID);
            Property(x => x.ExperienceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CompanyName).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            Property(x => x.JobName).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            Property(x => x.Place).HasColumnType("varchar").HasMaxLength(25).IsRequired();
            Property(x => x.Date).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasColumnType("varchar").IsRequired();
            Property(x => x.Technologies).HasColumnType("varchar").IsRequired();
        }
    }
}
