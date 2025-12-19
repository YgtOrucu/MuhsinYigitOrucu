namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(maxLength: 25, unicode: false),
                        Job = c.String(maxLength: 25, unicode: false),
                        ShortDescription = c.String(maxLength: 50, unicode: false),
                        LongDescription = c.String(maxLength: 8000, unicode: false),
                        Image = c.String(maxLength: 500, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        MailAddress = c.String(maxLength: 25, unicode: false),
                        Password = c.String(maxLength: 15, unicode: false),
                        Status = c.Boolean(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleType = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        EducationID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 25, unicode: false),
                        SubHeadingName = c.String(maxLength: 25, unicode: false),
                        SubHeadingName1 = c.String(maxLength: 25, unicode: false),
                        Description = c.String(maxLength: 250, unicode: false),
                        Date = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EducationID);
            
            CreateTable(
                "dbo.PortfolyoImages",
                c => new
                    {
                        PortfolyoImagesID = c.Int(nullable: false, identity: true),
                        Images = c.String(maxLength: 250, unicode: false),
                        PortfolyoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolyoImagesID)
                .ForeignKey("dbo.Portfolyo", t => t.PortfolyoID, cascadeDelete: true)
                .Index(t => t.PortfolyoID);
            
            CreateTable(
                "dbo.Portfolyo",
                c => new
                    {
                        PortfolyoID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 25, unicode: false),
                        Image = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.PortfolyoID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillsID = c.Int(nullable: false, identity: true),
                        SkillsName = c.String(nullable: false, maxLength: 100),
                        SkillsPercentage = c.String(maxLength: 3, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SkillsID);
            
            CreateTable(
                "dbo.SocialMedia",
                c => new
                    {
                        SocialMediaID = c.Int(nullable: false, identity: true),
                        Href = c.String(maxLength: 350, unicode: false),
                        IconAddress = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SocialMediaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PortfolyoImages", "PortfolyoID", "dbo.Portfolyo");
            DropForeignKey("dbo.Admin", "RoleID", "dbo.Role");
            DropIndex("dbo.PortfolyoImages", new[] { "PortfolyoID" });
            DropIndex("dbo.Admin", new[] { "RoleID" });
            DropTable("dbo.SocialMedia");
            DropTable("dbo.Skills");
            DropTable("dbo.Portfolyo");
            DropTable("dbo.PortfolyoImages");
            DropTable("dbo.Education");
            DropTable("dbo.Role");
            DropTable("dbo.Admin");
            DropTable("dbo.About");
        }
    }
}
