namespace NigmetAli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "IsValid", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "IsValid");
        }
    }
}
