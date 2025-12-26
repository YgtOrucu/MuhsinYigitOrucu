namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedANewColumnToAdminTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "About", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Admin", "Address", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Admin", "Phone", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Admin", "Image", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "Image");
            DropColumn("dbo.Admin", "Phone");
            DropColumn("dbo.Admin", "Address");
            DropColumn("dbo.Admin", "About");
        }
    }
}
