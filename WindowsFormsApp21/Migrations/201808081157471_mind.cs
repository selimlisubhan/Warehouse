namespace WindowsFormsApp21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mind : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        User_id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_id_Id)
                .Index(t => t.User_id_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Arrive = c.DateTime(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        Client_id_Id = c.Int(),
                        Product_id_Id = c.Int(),
                        User_id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customs", t => t.Client_id_Id)
                .ForeignKey("dbo.Prods", t => t.Product_id_Id)
                .ForeignKey("dbo.Users", t => t.User_id_Id)
                .Index(t => t.Client_id_Id)
                .Index(t => t.Product_id_Id)
                .Index(t => t.User_id_Id);
            
            CreateTable(
                "dbo.Prods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.String(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        User_id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_id_Id)
                .Index(t => t.User_id_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_id_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Product_id_Id", "dbo.Prods");
            DropForeignKey("dbo.Prods", "User_id_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Client_id_Id", "dbo.Customs");
            DropForeignKey("dbo.Customs", "User_id_Id", "dbo.Users");
            DropIndex("dbo.Prods", new[] { "User_id_Id" });
            DropIndex("dbo.Orders", new[] { "User_id_Id" });
            DropIndex("dbo.Orders", new[] { "Product_id_Id" });
            DropIndex("dbo.Orders", new[] { "Client_id_Id" });
            DropIndex("dbo.Customs", new[] { "User_id_Id" });
            DropTable("dbo.Prods");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Customs");
        }
    }
}
