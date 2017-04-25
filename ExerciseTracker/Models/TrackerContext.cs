using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExerciseTracker.Models
{
    public class TrackerContext : DbContext
    {
        public TrackerContext() : base("DefaultConnection")
        {

        }

        public DbSet<CompletedWorkout> CompletedWorkouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramTemplate> ProgramTemplates { get; set; }
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}