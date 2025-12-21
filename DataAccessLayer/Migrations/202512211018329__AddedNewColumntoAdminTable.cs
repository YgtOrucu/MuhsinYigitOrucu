namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _AddedNewColumntoAdminTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "NameSurname", c => c.String(maxLength: 25, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "NameSurname");
        }
    }
}
