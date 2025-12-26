namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedANewStatusColumnToPortfolyoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolyo", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolyo", "Status");
        }
    }
}
