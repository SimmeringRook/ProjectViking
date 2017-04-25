using ExerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseTracker.Utilities.Factories
{
    internal static class WorkoutFactory
    {
        internal static Utilites.Objects.Workout Create_Client_From_Database(Models.ProgramTemplate databaseWorkout)
        {
            if (databaseWorkout == null)
                return new Utilites.Objects.Workout();

            Utilites.Objects.Workout clientWorkout = new Utilites.Objects.Workout();
            clientWorkout.ID = databaseWorkout.WorkoutID;
            clientWorkout.Name = string.Copy(databaseWorkout.WorkoutName);

            using (TrackerContext trackerDatabase = new TrackerContext())
            {

                var workoutsForProgram = trackerDatabase.WorkoutTemplates.Where(w => w.WorkoutID == databaseWorkout.WorkoutID);
                foreach (Models.WorkoutTemplate template in workoutsForProgram)
                {
                    clientWorkout.Exercises.Add(ExerciseFactory.Create_Client_From_Database(template));
                }
            }

            return clientWorkout;
        }

        internal static Utilites.Objects.Workout Create_Client_From_Database(List<Models.CompletedWorkout> databaseWorkout)
        {
            if (databaseWorkout == null)
                return new Utilites.Objects.Workout();

            Utilites.Objects.Workout clientWorkout = new Utilites.Objects.Workout();
            clientWorkout.ID = databaseWorkout.First().WorkoutID;
            clientWorkout.DayCompleted = databaseWorkout.First().DayCompleted;
            clientWorkout.HasBeenCompleted = true;

            List<List<Models.CompletedWorkout>> groupedExercises = new List<List<Models.CompletedWorkout>>();

            foreach (var cw in databaseWorkout)
            {
                if (groupedExercises.Any(existingGroup => existingGroup.Any(grouped => grouped.ExerciseID == cw.ExerciseID)))
                    foreach (var group in groupedExercises)
                    {
                        if (group.Any(g => g.ExerciseID == cw.ExerciseID))
                            group.Add(cw);
                    }
                else
                    groupedExercises.Add(new List<Models.CompletedWorkout>() { cw });
            }

            groupedExercises.ForEach(group => { clientWorkout.Exercises.Add(ExerciseFactory.Create_Client_From_Database(group)); });

            using (TrackerContext trackerDatabase = new TrackerContext())
            {
                var cw = databaseWorkout.First();
                string workoutName = trackerDatabase.ProgramTemplates.SingleOrDefault(w => w.WorkoutID == cw.WorkoutID).WorkoutName;
                clientWorkout.Name = string.Copy(workoutName);
            }

            return clientWorkout;
        }

        internal static Models.WorkoutTemplate Create_Database_From_Client(Utilites.Objects.Workout clientProgram)
        {
            Models.WorkoutTemplate databaseProgram = new Models.WorkoutTemplate();
            return databaseProgram;
        }
    }
}