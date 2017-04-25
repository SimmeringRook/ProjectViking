using System;

namespace ExerciseTracker.Utilites.Objects
{
    public class CompletedWorkout
    {
        public string UserID { get; set; }
        //public User User { get; set; }

        //public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }

        public DateTime DayCompleted { get; set; }

        //public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }

        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// This creates an empty client-side object.
        /// </summary>
        public CompletedWorkout()
        {
            UserID = "";
            WorkoutName = "Empty";
            DayCompleted = DateTime.MinValue;
            ExerciseName = "Empty";
            SetNumber = 0;
            Reps = 0;
            Weight = 0.0;
        }
    }
}