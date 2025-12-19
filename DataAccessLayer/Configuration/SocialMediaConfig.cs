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
    public class SocialMediaConfig : EntityTypeConfiguration<SocialMedia>
    {
        public SocialMediaConfig()
        {
            HasKey(x => x.SocialMediaID);
            Property(x => x.SocialMediaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Href).HasColumnType("varchar").HasMaxLength(350);
            Property(x => x.IconAddress).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
