namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_tables : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OnlineClaimant");
            DropTable("dbo.OnlineExecutant");
            DropTable("dbo.OnlineIdentifier");
            DropTable("dbo.onlinePlot");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.onlinePlot",
                c => new
                    {
                        ackno = c.String(nullable: false, maxLength: 50),
                        DagNo = c.String(maxLength: 25, unicode: false),
                        PattaNo = c.String(maxLength: 25, unicode: false),
                        LandType = c.Short(),
                        Class = c.Short(),
                        Unit = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        State = c.String(maxLength: 30, unicode: false),
                        District = c.String(maxLength: 30, unicode: false),
                        Subdivision = c.String(maxLength: 30, unicode: false),
                        Circle = c.String(maxLength: 30, unicode: false),
                        Village = c.String(maxLength: 30, unicode: false),
                        TransactedArea = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        address1 = c.String(maxLength: 30),
                        address2 = c.String(maxLength: 30),
                        address3 = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ackno);
            
            CreateTable(
                "dbo.OnlineIdentifier",
                c => new
                    {
                        Ackno = c.String(nullable: false, maxLength: 50),
                        SlNo = c.Short(nullable: false),
                        IdentSurName = c.String(maxLength: 50),
                        IdentMiddleName = c.String(maxLength: 50),
                        IdentLastName = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 20),
                        Aadhaar = c.String(maxLength: 50),
                        Alias = c.String(maxLength: 50),
                        Identify = c.String(maxLength: 10),
                        Sex = c.String(maxLength: 1),
                        Occupation = c.Short(),
                        FatherSurName = c.String(maxLength: 50),
                        FatherMiddleName = c.String(maxLength: 50),
                        FatherLastName = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        District = c.String(maxLength: 50),
                        SubDivision = c.String(maxLength: 50),
                        Circle = c.String(maxLength: 50),
                        Village = c.String(maxLength: 50),
                        Street = c.String(maxLength: 150),
                        PostOffice = c.String(maxLength: 150),
                        PinCode = c.Int(),
                        PoliceSt = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.Ackno, t.SlNo });
            
            CreateTable(
                "dbo.OnlineExecutant",
                c => new
                    {
                        Ackno = c.String(nullable: false, maxLength: 50),
                        SlNo = c.Short(nullable: false),
                        ExecSurName = c.String(maxLength: 50, unicode: false),
                        ExecMiddleName = c.String(maxLength: 50, unicode: false),
                        ExecLastName = c.String(maxLength: 50, unicode: false),
                        Mobile = c.String(maxLength: 20),
                        Aadhaar = c.String(maxLength: 50),
                        Alias = c.String(maxLength: 50, unicode: false),
                        Sex = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Occupation = c.Short(),
                        FatherSurName = c.String(maxLength: 50, unicode: false),
                        FatherMiddleName = c.String(maxLength: 50, unicode: false),
                        FatherLastName = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 50, unicode: false),
                        District = c.String(maxLength: 50, unicode: false),
                        SubDivision = c.String(maxLength: 50, unicode: false),
                        Circle = c.String(maxLength: 50, unicode: false),
                        Village = c.String(maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 150, unicode: false),
                        PostOffice = c.String(maxLength: 150, unicode: false),
                        PinCode = c.Int(),
                        PoliceSt = c.String(maxLength: 100, unicode: false),
                        EnterBy = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => new { t.Ackno, t.SlNo });
            
            CreateTable(
                "dbo.OnlineClaimant",
                c => new
                    {
                        Ackno = c.String(nullable: false, maxLength: 50),
                        SlNo = c.Short(nullable: false),
                        ClaimSurName = c.String(maxLength: 50),
                        ClaimMiddleName = c.String(maxLength: 50),
                        ClaimLastName = c.String(maxLength: 50),
                        Alias = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 20),
                        Aadhaar = c.String(maxLength: 50),
                        Sex = c.String(maxLength: 1),
                        Occupation = c.Short(),
                        FatherSurName = c.String(maxLength: 50),
                        FatherMiddleName = c.String(maxLength: 50),
                        FatherLastName = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        District = c.String(maxLength: 50),
                        SubDivision = c.String(maxLength: 50),
                        Circle = c.String(maxLength: 50),
                        Village = c.String(maxLength: 50),
                        Street = c.String(maxLength: 150),
                        PostOffice = c.String(maxLength: 150),
                        PinCode = c.Int(),
                        PoliceSt = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.Ackno, t.SlNo });
            
        }
    }
}
