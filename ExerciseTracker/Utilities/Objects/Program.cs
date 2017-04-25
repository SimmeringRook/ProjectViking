using System.Collections.Generic;

namespace ExerciseTracker.Utilites.Objects
{
    public class Program
    {
        public int ID;
        public string Name { get; set; }
        public List<Workout> Workouts { get; set; }

        public Program()
        {
            ID = 0;
            Name = "Empty";
            Workouts = new List<Workout>();
        }
    }
}