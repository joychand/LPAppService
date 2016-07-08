namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_appointment2_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        TSNo = c.Int(nullable: false),
                        TSYear = c.Short(nullable: false),
                        sro = c.String(nullable: false, maxLength: 50),
                        date1 = c.DateTime(nullable: false),
                        date2 = c.DateTime(),
                        date3 = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.TSNo, t.TSYear, t.sro });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appointments");
        }
    }
}
