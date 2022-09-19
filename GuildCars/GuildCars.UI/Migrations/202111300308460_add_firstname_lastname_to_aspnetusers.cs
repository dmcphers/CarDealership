namespace GuildCars.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_firstname_lastname_to_aspnetusers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: true));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
