namespace NigmetAli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueEmail : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Members", new[] { "EMail" });
            //CreateIndex("dbo.Members", "EMail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "EMail" });
        }
    }
}
