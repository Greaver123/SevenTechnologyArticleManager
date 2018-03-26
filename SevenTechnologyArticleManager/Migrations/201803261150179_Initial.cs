namespace SevenTechnologyArticleManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cenniki",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 255, unicode: false),
                        Data_Od = c.DateTime(),
                        Data_Do = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ceny",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CennikId = c.Int(),
                        TowarId = c.Int(),
                        Cena = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Rabat = c.Decimal(precision: 5, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towary", t => t.TowarId)
                .ForeignKey("dbo.Cenniki", t => t.CennikId)
                .Index(t => t.CennikId)
                .Index(t => t.TowarId);
            
            CreateTable(
                "dbo.Towary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kod = c.String(nullable: false, maxLength: 7, unicode: false),
                        Nazwa = c.String(nullable: false, maxLength: 255, unicode: false),
                        Masa = c.Decimal(precision: 14, scale: 3),
                        JM = c.String(maxLength: 50, unicode: false),
                        Data_Utworzenia = c.DateTime(),
                        Data_Modyfikacji = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ceny", "CennikId", "dbo.Cenniki");
            DropForeignKey("dbo.Ceny", "TowarId", "dbo.Towary");
            DropIndex("dbo.Ceny", new[] { "TowarId" });
            DropIndex("dbo.Ceny", new[] { "CennikId" });
            DropTable("dbo.Towary");
            DropTable("dbo.Ceny");
            DropTable("dbo.Cenniki");
        }
    }
}
