namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedStatusColumnToPortfolyoImageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PortfolyoImages", "Status", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.PortfolyoImages", "Status");
        }
    }
}
