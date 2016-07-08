namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreate_table2 : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.OnlineExecutant",
                c => new
                    {
                        Ackno = c.String(nullable: false, maxLength: 50),
                        SlNo = c.Short(nullable: false),
                        ExecSurName = c.String(maxLength: 50),
                        ExecMiddleName = c.String(maxLength: 50),
                        ExecLastName = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 20),
                        Aadhaar = c.String(maxLength: 50),
                        Alias = c.String(maxLength: 50),
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
                        EnterBy = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => new { t.Ackno, t.SlNo });
            
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
                "dbo.onlinePlot",
                c => new
                    {
                        ackno = c.String(nullable: false, maxLength: 50),
                        DagNo = c.String(maxLength: 25),
                        PattaNo = c.String(maxLength: 25),
                        LandType = c.Short(),
                        Class = c.Short(),
                        Unit = c.String(maxLength: 1),
                        State = c.String(maxLength: 30),
                        District = c.String(maxLength: 30),
                        Subdivision = c.String(maxLength: 30),
                        Circle = c.String(maxLength: 30),
                        Village = c.String(maxLength: 30),
                        TransactedArea = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        address1 = c.String(maxLength: 30),
                        address2 = c.String(maxLength: 30),
                        address3 = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ackno);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.onlinePlot");
            DropTable("dbo.OnlineIdentifier");
            DropTable("dbo.OnlineExecutant");
            DropTable("dbo.OnlineClaimant");
        }
    }
}
