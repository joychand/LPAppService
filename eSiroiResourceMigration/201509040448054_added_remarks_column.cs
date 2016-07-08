namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_remarks_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "remarks", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "remarks");
        }
    }
}
