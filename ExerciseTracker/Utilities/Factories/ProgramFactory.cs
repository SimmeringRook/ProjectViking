using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseTracker.Utilities.Factories
{
    internal static class ProgramFactory
    {
        internal static Utilites.Objects.Program Create_Client_From_Database(Models.Program databaseProgram)
        {
            if (databaseProgram == null)
                return new Utilites.Objects.Program();

            Utilites.Objects.Program clientProgram = new Utilites.Objects.Program();
            clientProgram.ID = databaseProgram.ProgramID;
            clientProgram.Name = string.Copy(databaseProgram.ProgramName);

            using (Models.TrackerContext trackerDatabase = new Models.TrackerContext())
            {

                var workoutsForProgram = trackerDatabase.ProgramTemplates.Where(p => p.ProgramID == databaseProgram.ProgramID);

                foreach (Models.ProgramTemplate template in workoutsForProgram)
                {
                    clientProgram.Workouts.Add(WorkoutFactory.Create_Client_From_Database(template));
                }
            }

            return clientProgram;
        }

        internal static Models.Program Create_Database_From_Client(Utilites.Objects.Program clientProgram)
        {
            Models.Program databaseProgram = new Models.Program();
            return databaseProgram;
        }
    }
}