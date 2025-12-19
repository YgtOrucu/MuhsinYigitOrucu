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
    public class PortfolyoImageConfig : EntityTypeConfiguration<PortfolyoImages>
    {
        public PortfolyoImageConfig()
        {
            HasKey(x => x.PortfolyoImagesID);
            Property(x => x.PortfolyoImagesID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Images).HasColumnType("varchar").HasMaxLength(250);
        }
    }
}
