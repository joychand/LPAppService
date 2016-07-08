namespace eSiroi.Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addownno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UniCircle",
                c => new
                    {
                        circode = c.String(nullable: false, maxLength: 3),
                        distcode = c.String(maxLength: 2),
                        subcode = c.String(maxLength: 2),
                        cirDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.circode);
            
            CreateTable(
                "dbo.UniDistrict",
                c => new
                    {
                        distcode = c.String(nullable: false, maxLength: 2),
                        distDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.distcode);
            
            CreateTable(
                "dbo.UniLocation",
                c => new
                    {
                        LocCd = c.String(nullable: false, maxLength: 10),
                        LocDesc = c.String(maxLength: 100),
                        Issue = c.String(maxLength: 1),
                        Unit_Measurement = c.String(maxLength: 1),
                        Mandol = c.Byte(),
                    })
                .PrimaryKey(t => t.LocCd);
            
            CreateTable(
                "dbo.Uniowner",
                c => new
                    {
                        LocCd = c.String(nullable: false, maxLength: 10),
                        NewDagNo = c.String(nullable: false, maxLength: 30),
                        ownno = c.Int(),
                        NewPattaNo = c.String(maxLength: 30),
                        Name = c.String(maxLength: 150),
                        Father = c.String(maxLength: 150),
                        Address = c.String(maxLength: 150),
                        PArea = c.Double(),
                        OFlag = c.String(maxLength: 1),
                        MutNo = c.Decimal(precision: 18, scale: 0),
                        SocialClass = c.String(maxLength: 7, unicode: false),
                    })
                .PrimaryKey(t => new { t.LocCd, t.NewDagNo });
            
            CreateTable(
                "dbo.Uniplot",
                c => new
                    {
                        LocCd = c.String(nullable: false, maxLength: 10),
                        NewDagNo = c.String(nullable: false, maxLength: 30),
                        ExNewDag = c.String(maxLength: 30),
                        OldDagNo = c.String(maxLength: 30),
                        Area = c.Double(),
                        Area_acre = c.Double(),
                        OldPattaNo = c.String(maxLength: 30),
                        NewPattaNo = c.String(maxLength: 30),
                        ExNewPatta = c.String(maxLength: 30),
                        KhatianNo = c.String(maxLength: 10),
                        CropDesc = c.String(maxLength: 20),
                        CropArea = c.Double(),
                        DouCropArea = c.Double(),
                        FaOrWaste = c.String(maxLength: 20),
                        UnCropArea = c.Double(),
                        Product = c.String(maxLength: 20),
                        IrriLand = c.Double(),
                        LandClass = c.String(maxLength: 20),
                        UnSetDesc = c.String(maxLength: 20),
                        UnSetArea = c.Double(),
                        OpCd = c.String(maxLength: 2),
                        EntryDate = c.String(maxLength: 10, fixedLength: true),
                        SlNo = c.String(maxLength: 10),
                        OrdNo = c.String(maxLength: 50),
                        OrDate = c.String(maxLength: 15),
                        RemarkType = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        remark = c.String(maxLength: 300),
                        sheet = c.Short(),
                        unit = c.String(maxLength: 5),
                        survey = c.String(maxLength: 4),
                        usr = c.String(maxLength: 10, unicode: false),
                        MutNo = c.Decimal(precision: 18, scale: 0),
                        Revenue = c.Double(),
                        Year = c.String(maxLength: 4),
                        MutOld = c.Decimal(precision: 18, scale: 0),
                        VerifiedBy = c.Byte(),
                    })
                .PrimaryKey(t => new { t.LocCd, t.NewDagNo });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uniplot");
            DropTable("dbo.Uniowner");
            DropTable("dbo.UniLocation");
            DropTable("dbo.UniDistrict");
            DropTable("dbo.UniCircle");
        }
    }
}
