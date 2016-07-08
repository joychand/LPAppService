namespace eSiroi.Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conersionofownnotype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uniowner", "ownno", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uniowner", "ownno", c => c.Int());
        }
    }
}
