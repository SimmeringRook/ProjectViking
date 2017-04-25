using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Models
{
    public class WorkoutTemplate
    {
        
        public int WorkoutID { get; set; }

        public int ExerciseID { get; set; }

        [Key]
        public int WorkoutTemplateID { get; set; }

        [Required, Display(Name = "Number of Sets")]
        public int NumberOfSets { get; set; }

        [Required, Display(Name = "Rep Range")]
        public string RepRange { get; set; }

        [ForeignKey("ExerciseID"), Column(Order = 2)]
        internal virtual Exercise Exercise { get; set; }

        [ForeignKey("WorkoutID"), Column(Order = 1)]
        internal virtual ProgramTemplate ProgramTemplate { get; set; }
    }
}