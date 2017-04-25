using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Models
{
    public class CompletedWorkout
    {
        [Key]
        [Column(Order = 1)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int WorkoutID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int ExerciseID { get; set; }

        [Key]
        [Column(Order = 4)]
        public System.DateTime DayCompleted { get; set; }

        [Key, Column(Order = 5) Display(Name = "Set Number")]
        public int SetNumber { get; set; }

        [Required, Display(Name = "Reps")]
        public int Reps { get; set; }

        [Required, Display(Name = "Weight")]
        public double Weight { get; set; }

        internal virtual Exercise Exercise { get; set; }

        internal virtual ProgramTemplate ProgramTemplate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}