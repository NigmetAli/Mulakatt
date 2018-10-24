namespace NigmetAli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueEmail : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Members", "EMail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "EMail" });
        }
    }
}
