namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Tb_M_Employee", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Tb_M_Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Nama = c.String(),
                        Posisi = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Account", "AccountId", "dbo.Tb_M_Employee");
            DropIndex("dbo.Tb_M_Account", new[] { "AccountId" });
            DropTable("dbo.Tb_M_Employee");
            DropTable("dbo.Tb_M_Account");
        }
    }
}
