namespace Project_ProductMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CategoryId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
        }
    }
}
