namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGitHubUrlColumnToPortfolyoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolyo", "GitHubUrl", c => c.String(maxLength: 45, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolyo", "GitHubUrl");
        }
    }
}
