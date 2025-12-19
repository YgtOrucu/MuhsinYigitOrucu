using DataAccessLayer.Configuration;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class MYOContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Portfolyo> Portfolyos { get; set; }
        public DbSet<PortfolyoImages> PortfolyoImages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skills> Skills  { get; set; }
        public DbSet<SocialMedia> SocialMedias  { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AboutConfig());
            modelBuilder.Configurations.Add(new AdminConfig());
            modelBuilder.Configurations.Add(new EducationConfig());
            modelBuilder.Configurations.Add(new PortfolyoConfig());
            modelBuilder.Configurations.Add(new PortfolyoImageConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new SkillsConfig());
            modelBuilder.Configurations.Add(new SocialMediaConfig());
        }
    }
}
