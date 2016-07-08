namespace eSiroi.Resource.eSiroiResourceMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deed_table_modefied : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deed", "RegDate", c => c.String(maxLength: 100));
            AlterColumn("dbo.Deed", "Date_Exec", c => c.String(maxLength: 100));
            AlterColumn("dbo.Deed", "Date_Time_Present", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Deed", "Date_Time_Present", c => c.DateTime());
            AlterColumn("dbo.Deed", "Date_Exec", c => c.DateTime());
            AlterColumn("dbo.Deed", "RegDate", c => c.DateTime());
        }
    }
}
