namespace NigmetAli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regenerated : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Members", new[] { "EMail" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Members", "EMail", unique: true);
        }
    }
}
