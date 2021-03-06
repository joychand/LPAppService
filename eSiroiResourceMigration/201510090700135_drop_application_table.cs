namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_application_table : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Applications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        TSNo = c.Int(nullable: false),
                        TSYear = c.Short(nullable: false),
                        sro = c.String(nullable: false, maxLength: 50),
                        ackno = c.Int(),
                        trans_maj_code = c.String(maxLength: 2),
                        Entrydate = c.String(maxLength: 50),
                        status = c.String(maxLength: 50),
                        remarks = c.String(maxLength: 50),
                        filePath = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.TSNo, t.TSYear, t.sro });
            
        }
    }
}
