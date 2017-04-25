namespace ExerciseTracker.Utilites.Objects
{
    public struct ExerciseInfo
    {
        public int Reps { get; set; }
        public double Weight { get; set; }

        public ExerciseInfo(int reps, double weight)
        {
            Reps = reps;
            Weight = weight;
        }
    }
}