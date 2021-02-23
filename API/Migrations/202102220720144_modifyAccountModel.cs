namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAccountModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Account", "Passwords", c => c.String());
            DropColumn("dbo.Tb_M_Account", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_M_Account", "Password", c => c.String());
            DropColumn("dbo.Tb_M_Account", "Passwords");
        }
    }
}
