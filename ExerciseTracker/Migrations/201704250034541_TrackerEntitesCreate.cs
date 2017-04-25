namespace ExerciseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrackerEntitesCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompletedWorkouts",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        WorkoutID = c.Int(nullable: false),
                        ExerciseID = c.Int(nullable: false),
                        DayCompleted = c.DateTime(nullable: false),
                        SetNumber = c.Int(nullable: false),
                        Reps = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.WorkoutID, t.ExerciseID, t.DayCompleted, t.SetNumber })
                .ForeignKey("dbo.Exercises", t => t.ExerciseID, cascadeDelete: true)
                .ForeignKey("dbo.ProgramTemplates", t => t.WorkoutID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.WorkoutID)
                .Index(t => t.ExerciseID);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseID);
            
            CreateTable(
                "dbo.ProgramTemplates",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        ProgramID = c.Int(nullable: false),
                        WorkoutName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutID)
                .ForeignKey("dbo.Programs", t => t.ProgramID)
                .Index(t => t.ProgramID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramID);
            
            CreateTable(
                "dbo.WorkoutTemplates",
                c => new
                    {
                        WorkoutTemplateID = c.Int(nullable: false, identity: true),
                        WorkoutID = c.Int(nullable: false),
                        ExerciseID = c.Int(nullable: false),
                        NumberOfSets = c.Int(nullable: false),
                        RepRange = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutTemplateID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseID, cascadeDelete: true)
                .ForeignKey("dbo.ProgramTemplates", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.WorkoutID)
                .Index(t => t.ExerciseID);
            
            AddColumn("dbo.AspNetUsers", "ActiveProgramID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ActiveProgramID");
            AddForeignKey("dbo.AspNetUsers", "ActiveProgramID", "dbo.Programs", "ProgramID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutTemplates", "WorkoutID", "dbo.ProgramTemplates");
            DropForeignKey("dbo.WorkoutTemplates", "ExerciseID", "dbo.Exercises");
            DropForeignKey("dbo.CompletedWorkouts", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompletedWorkouts", "WorkoutID", "dbo.ProgramTemplates");
            DropForeignKey("dbo.ProgramTemplates", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.AspNetUsers", "ActiveProgramID", "dbo.Programs");
            DropForeignKey("dbo.CompletedWorkouts", "ExerciseID", "dbo.Exercises");
            DropIndex("dbo.WorkoutTemplates", new[] { "ExerciseID" });
            DropIndex("dbo.WorkoutTemplates", new[] { "WorkoutID" });
            DropIndex("dbo.AspNetUsers", new[] { "ActiveProgramID" });
            DropIndex("dbo.ProgramTemplates", new[] { "ProgramID" });
            DropIndex("dbo.CompletedWorkouts", new[] { "ExerciseID" });
            DropIndex("dbo.CompletedWorkouts", new[] { "WorkoutID" });
            DropIndex("dbo.CompletedWorkouts", new[] { "UserID" });
            DropColumn("dbo.AspNetUsers", "ActiveProgramID");
            DropTable("dbo.WorkoutTemplates");
            DropTable("dbo.Programs");
            DropTable("dbo.ProgramTemplates");
            DropTable("dbo.Exercises");
            DropTable("dbo.CompletedWorkouts");
        }
    }
}
