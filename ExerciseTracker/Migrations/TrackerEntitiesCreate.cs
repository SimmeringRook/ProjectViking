using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ExerciseTracker.Migrations
{
    public class TrackerEntitiesCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Exercise",
            c => new
            {
                ExerciseID = c.Int(nullable: false, identity: true),
                ExerciseName = c.String(nullable: false),
            })
            .PrimaryKey(t => t.ExerciseID);

            CreateTable(
                "dbo.Program",
                c => new
                {
                    ProgramID = c.Int(nullable: false, identity: true),
                    ProgramName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ProgramID);

            CreateTable(
                "dbo.ProgramTemplate",
                c => new
                {
                    WorkoutID = c.Int(nullable: false, identity: true),
                    ProgramID = c.Int(nullable: false),
                    WorkoutName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.WorkoutID)
                .ForeignKey("dbo.Program", t => t.ProgramID, cascadeDelete: true);

            CreateTable(
                "dbo.WorkoutTemplate",
                c => new
                {
                    WorkoutTemplateID = c.Int(nullable: false, identity: true),
                    WorkoutID = c.Int(nullable: false),
                    ExerciseID = c.Int(nullable: false),
                    NumberOfSets = c.Int(),
                    RepRange = c.String(),
                })
                .PrimaryKey(t => t.WorkoutTemplateID)
                .ForeignKey("dbo.ProgramTemplate", t => t.WorkoutID, cascadeDelete: true)
                .ForeignKey("dbo.Exercise", t => t.ExerciseID);

            CreateTable(
                "dbo.CompletedWorkout",
                c => new
                {
                    UserID = c.String(nullable: false),
                    WorkoutID = c.Int(nullable: false),
                    ExerciseID = c.Int(nullable: false),
                    DayCompleted = c.DateTime(nullable: false),
                    SetNumber = c.Int(nullable: false),
                    RepRange = c.Int(nullable: false),
                    Weight = c.Double(nullable: false)
                })
                .PrimaryKey(t => t.UserID)
                .PrimaryKey(t => t.WorkoutID)
                .PrimaryKey(t => t.ExerciseID)
                .PrimaryKey(t => t.DayCompleted)
                .PrimaryKey(t => t.SetNumber)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.ProgramTemplate", t => t.WorkoutID)
                .ForeignKey("dbo.Exercise", t => t.ExerciseID);

            AddColumn("dbo.AspNetUsers", "ActiveProgramID", c => c.Int(nullable: false));
            AddForeignKey("dbo.AspNetUsers", "ActiveProgramID", "dbo.Program", "ProgramID");
        }

        public override void Down()
        {
            base.Down();
        }
    }
}