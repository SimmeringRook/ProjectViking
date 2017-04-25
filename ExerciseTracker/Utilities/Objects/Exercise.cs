using System.Collections.Generic;

namespace ExerciseTracker.Utilites.Objects
{
    public class Exercise
    {
        public string Name { get; set; }
        public Dictionary<int, ExerciseInfo> Sets { get; set; }
        public string RepRange { get; set; }
        public Exercise()
        {
            Name = "Exercise Not Found";
            Sets = new Dictionary<int, ExerciseInfo>();
            RepRange = "Error";
        }
    }
}