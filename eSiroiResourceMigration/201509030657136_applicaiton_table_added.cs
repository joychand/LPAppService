namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicaiton_table_added : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => new { t.TSNo, t.TSYear, t.sro });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applications");
        }
    }
}
