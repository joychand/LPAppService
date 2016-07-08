namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_remarks_onlineapplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.onlineapplication", "remarks", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.onlineapplication", "remarks");
        }
    }
}
