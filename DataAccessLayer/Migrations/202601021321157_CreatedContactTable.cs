namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedContactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(maxLength: 30, unicode: false),
                        Mail = c.String(maxLength: 25, unicode: false),
                        Subject = c.String(maxLength: 30, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
