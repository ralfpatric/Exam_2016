namespace Exam_2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "NextYearlyInterview");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NextYearlyInterview", c => c.String());
        }
    }
}
