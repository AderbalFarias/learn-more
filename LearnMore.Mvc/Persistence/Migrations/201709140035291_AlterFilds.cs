using System.Data.Entity.Migrations;

namespace LearnMore.Mvc.Persistence.Migrations
{
    public partial class AlterFilds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendances", name: "Event_Id", newName: "EventId");
            RenameIndex(table: "dbo.Attendances", name: "IX_Event_Id", newName: "IX_EventId");
            DropPrimaryKey("dbo.Attendances");
            AddPrimaryKey("dbo.Attendances", new[] { "EventId", "AttendeeId" });
            DropColumn("dbo.Attendances", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "EventId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Attendances");
            AddPrimaryKey("dbo.Attendances", new[] { "EventId", "AttendeeId" });
            RenameIndex(table: "dbo.Attendances", name: "IX_EventId", newName: "IX_Event_Id");
            RenameColumn(table: "dbo.Attendances", name: "EventId", newName: "Event_Id");
        }
    }
}
