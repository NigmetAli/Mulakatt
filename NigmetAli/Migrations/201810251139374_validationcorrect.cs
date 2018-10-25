namespace NigmetAli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationcorrect : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "IsValid", c => c.String(nullable: false));
        }
    }
}
