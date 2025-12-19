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
    public class EducationConfig : EntityTypeConfiguration<Education>
    {
        public EducationConfig()
        {
            HasKey(x => x.EducationID);
            Property(x => x.EducationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.HeadingName).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.SubHeadingName).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.SubHeadingName1).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.Description).HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.Date).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
