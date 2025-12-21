namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPasswordColumnLenghtToAdminTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin", "Password", c => c.String(maxLength: 80, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admin", "Password", c => c.String(maxLength: 15, unicode: false));
        }
    }
}
