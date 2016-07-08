namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_upload_filepath_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "filePath", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "filePath");
        }
    }
}
