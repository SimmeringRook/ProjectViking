using System.Collections.Generic;
using System.Linq;

namespace ExerciseTracker.Utilities.Factories
{
    internal class ExerciseFactory
    {
        private static Dictionary<int, string> _ExerciseMap = _BuildExerciseMap();
        private static Dictionary<int, string> _BuildExerciseMap()
        {
            _ExerciseMap = new Dictionary<int, string>();
            using (Models.TrackerContext trackerDatabase = new Models.TrackerContext())
            {
                var allExercises = trackerDatabase.Exercises.ToList();
                allExercises.ForEach(exercise =>
                {
                    if (_ExerciseMap.Keys.Contains(exercise.ExerciseID) == false)
                        _ExerciseMap.Add(exercise.ExerciseID, exercise.ExerciseName);
                });
            }
            return _ExerciseMap;
        }

        internal static Utilites.Objects.Exercise Create_Client_From_Database(Models.WorkoutTemplate databaseWorkoutTemplate)
        {
            if (databaseWorkoutTemplate == null)
                return new Utilites.Objects.Exercise();

            Utilites.Objects.Exercise clientExercise = new Utilites.Objects.Exercise();

            string name = string.Empty;
            if (_ExerciseMap.TryGetValue(databaseWorkoutTemplate.ExerciseID, out name))
                clientExercise.Name = string.Copy(name);

            for (int i = 1; i <= databaseWorkoutTemplate.NumberOfSets; i++)
                clientExercise.Sets.Add(i, new Utilites.Objects.ExerciseInfo());

            clientExercise.RepRange = string.Copy(databaseWorkoutTemplate.RepRange);

            return clientExercise;
        }

        internal static Utilites.Objects.Exercise Create_Client_From_Database(List<Models.CompletedWorkout> databaseCompletedWorkout)
        {
            if (databaseCompletedWorkout == null)
                return new Utilites.Objects.Exercise();

            Utilites.Objects.Exercise clientExercise = new Utilites.Objects.Exercise();

            string name = string.Empty;
            if (_ExerciseMap.TryGetValue(databaseCompletedWorkout.First().ExerciseID, out name))
                clientExercise.Name = string.Copy(name);

            for (int i = 0; i < databaseCompletedWorkout.Count; i++)
                clientExercise.Sets.Add(i + 1, new Utilites.Objects.ExerciseInfo(databaseCompletedWorkout[i].Reps, databaseCompletedWorkout[i].Weight));

            return clientExercise;
        }
    }
}