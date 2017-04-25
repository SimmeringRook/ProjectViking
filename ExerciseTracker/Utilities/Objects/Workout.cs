using System;
using System.Collections.Generic;

namespace ExerciseTracker.Utilites.Objects
{
    public class Workout
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool HasBeenCompleted { get; set; }
        public DateTime DayCompleted { get; set; }

        public List<Exercise> Exercises { get; set; }

        public Workout()
        {
            ID = 0;
            Name = "Empty";
            HasBeenCompleted = false;
            DayCompleted = DateTime.MinValue;
            Exercises = new List<Exercise>();
        }

        /// <summary>
        /// Returns the Date Completed in "MMM dd, yyyy" Format
        /// </summary>
        public string GetDateToString()
        {
            return DayCompleted.Date.ToString("MMM dd, yyyy");
        }
    }
}