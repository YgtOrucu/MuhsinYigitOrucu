namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumnDescriptionToEducationAndAddedNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 30, unicode: false),
                        JobName = c.String(nullable: false, maxLength: 40, unicode: false),
                        Place = c.String(nullable: false, maxLength: 25, unicode: false),
                        Description = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Technologies = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Date = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            DropColumn("dbo.Education", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Education", "Description", c => c.String(maxLength: 250, unicode: false));
            DropTable("dbo.Experience");
        }
    }
}
