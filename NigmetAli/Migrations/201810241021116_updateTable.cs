namespace NigmetAli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "IsTrue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Questions", "HasTrue", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Members", "EMail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "EMail", c => c.String());
            DropColumn("dbo.Questions", "HasTrue");
            DropColumn("dbo.Members", "UserName");
            DropColumn("dbo.Answers", "IsTrue");
        }
    }
}
