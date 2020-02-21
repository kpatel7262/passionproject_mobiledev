namespace passionproject_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodytypes",
                c => new
                    {
                        BodytypeID = c.Int(nullable: false, identity: true),
                        BodytypeName = c.String(),
                    })
                .PrimaryKey(t => t.BodytypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bodytypes");
        }
    }
}
