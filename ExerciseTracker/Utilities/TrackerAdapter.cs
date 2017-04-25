using ExerciseTracker.Utilites.Objects;
using ExerciseTracker.Utilities.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseTracker.Utilities
{
    public static class TrackerAdapter
    {
        //public static List<CompletedWorkout> GetWorkoutsForUser(int userID)
        //{
        //    List<Models.CompletedWorkout> workoutsForUser = new List<Models.CompletedWorkout>();

        //    using (Models.TrackerContext trackerDatbase = new Models.TrackerContext())
        //    {
        //        var allWorkouts = trackerDatbase.CompletedWorkouts.Where(w => w.UserID.Equals(userID)).ToList();
        //        foreach (var workout in allWorkouts)
        //            workoutsForUser.Add(CompletedWorkoutFactory.Create_Client_From_Database(workout));
        //    }

        //    return workoutsForUser;
        //}

        public static Program GeActiveProgramForUser(Models.ApplicationUser user)
        {
            return GetPrograms().Where(p => p.ID == 1).FirstOrDefault();
        }

        public static List<Program> GetPrograms()
        {
            List<Program> allPrograms = new List<Program>();

            using (Models.TrackerContext trackerDatabase = new Models.TrackerContext())
            {
                var programs = trackerDatabase.Programs.ToList();
                programs.ForEach(p => { allPrograms.Add(ProgramFactory.Create_Client_From_Database(p)); });
            }

            return allPrograms;
        }
    }
}