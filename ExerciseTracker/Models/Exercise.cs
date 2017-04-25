using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }

        [Required, Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }

        
        internal virtual ICollection<CompletedWorkout> CompletedWorkouts { get; set; }
        

        internal virtual ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}