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
    public class ContactConfig : EntityTypeConfiguration<Contact>
    {
        public ContactConfig()
        {
            HasKey(x => x.ContactID);
            Property(x => x.ContactID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NameSurname).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Mail).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.Subject).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Description).HasColumnType("varchar");
        }
    }
}
