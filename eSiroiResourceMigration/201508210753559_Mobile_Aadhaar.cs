namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mobile_Aadhaar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claimant", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Claimant", "Aadhaar", c => c.String(maxLength: 50));
            AddColumn("dbo.Executant", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Executant", "Aadhaar", c => c.String(maxLength: 50));
            AddColumn("dbo.Identifier", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Identifier", "Aadhaar", c => c.String(maxLength: 50));
            AddColumn("dbo.OnlineClaimant", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.OnlineClaimant", "Aadhaar", c => c.String(maxLength: 50));
            AddColumn("dbo.OnlineExecutant", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.OnlineExecutant", "Aadhaar", c => c.String(maxLength: 50));
            AddColumn("dbo.OnlineIdentifier", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.OnlineIdentifier", "Aadhaar", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OnlineIdentifier", "Aadhaar");
            DropColumn("dbo.OnlineIdentifier", "Mobile");
            DropColumn("dbo.OnlineExecutant", "Aadhaar");
            DropColumn("dbo.OnlineExecutant", "Mobile");
            DropColumn("dbo.OnlineClaimant", "Aadhaar");
            DropColumn("dbo.OnlineClaimant", "Mobile");
            DropColumn("dbo.Identifier", "Aadhaar");
            DropColumn("dbo.Identifier", "Mobile");
            DropColumn("dbo.Executant", "Aadhaar");
            DropColumn("dbo.Executant", "Mobile");
            DropColumn("dbo.Claimant", "Aadhaar");
            DropColumn("dbo.Claimant", "Mobile");
        }
    }
}
