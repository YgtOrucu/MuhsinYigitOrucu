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
    public class SkillsConfig : EntityTypeConfiguration<Skills>
    {
        public SkillsConfig()
        {
            HasKey(x => x.SkillsID);
            Property(x => x.SkillsID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SkillsName).HasMaxLength(100).IsRequired();
            Property(x => x.SkillsPercentage).HasColumnType("varchar").HasMaxLength(3);
        }
    }
}
