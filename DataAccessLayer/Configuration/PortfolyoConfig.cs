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
    public class PortfolyoConfig : EntityTypeConfiguration<Portfolyo>
    {
        public PortfolyoConfig()
        {
            HasKey(x => x.PortfolyoID);
            Property(x => x.PortfolyoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.HeadingName).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.Image).HasColumnType("varchar").HasMaxLength(250);
        }
    }
}
