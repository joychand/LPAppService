namespace eSiroi.Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addownno2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uniowner", "ownno", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uniowner", "ownno");
        }
    }
}
