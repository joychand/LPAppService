namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterearthQuake : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MasterLandValue",
            //    c => new
            //        {
            //            Unit = c.String(nullable: false, maxLength: 50),
            //            SN = c.Short(),
            //            Rate1 = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
            //            Rate2 = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
            //            Rate3 = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
            //            Details = c.String(maxLength: 200),
            //            Remark1 = c.String(maxLength: 50),
            //            Remark2 = c.String(maxLength: 50),
            //            Remark3 = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Unit);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.MasterLandValue");
        }
    }
}
