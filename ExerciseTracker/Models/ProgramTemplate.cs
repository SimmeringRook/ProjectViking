using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Models
{
    public class ProgramTemplate
    {
        [Key]
        public int WorkoutID { get; set; }

        
        public int ProgramID { get; set; }

        [Required, Display(Name = "Name")]
        public string WorkoutName { get; set; }

        internal virtual ICollection<CompletedWorkout> CompletedWorkouts { get; set; }

        [ForeignKey("ProgramID")]
        internal virtual Program Program { get; set; }
        internal virtual ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}