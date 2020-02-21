namespace passionproject_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkkk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "BrandID", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "BodytypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "BrandID");
            CreateIndex("dbo.Cars", "BodytypeID");
            AddForeignKey("dbo.Cars", "BodytypeID", "dbo.Bodytypes", "BodytypeID", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "BrandID", "dbo.Brands", "BrandID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Cars", "BodytypeID", "dbo.Bodytypes");
            DropIndex("dbo.Cars", new[] { "BodytypeID" });
            DropIndex("dbo.Cars", new[] { "BrandID" });
            DropColumn("dbo.Cars", "BodytypeID");
            DropColumn("dbo.Cars", "BrandID");
        }
    }
}
