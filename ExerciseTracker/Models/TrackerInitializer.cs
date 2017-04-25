using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ExerciseTracker.Models
{
    public class TrackerInitializer : DropCreateDatabaseIfModelChanges<TrackerContext>
    {
        protected override void Seed(TrackerContext context)
        {
            GetPrograms().ForEach(program => context.Programs.AddOrUpdate(program));
            context.SaveChanges();

            GetProgramTemplates().ForEach(programTemplate => context.ProgramTemplates.AddOrUpdate(programTemplate));
            context.SaveChanges();

            GetWorkoutTemplates().ForEach(workoutTemplate => context.WorkoutTemplates.AddOrUpdate(workoutTemplate));
            context.SaveChanges();

            GetExercises().ForEach(exercise => context.Exercises.AddOrUpdate(exercise));
            context.SaveChanges();
        }

        private static List<Program> GetPrograms()
        {
            var programs = new List<Program>
            {
                new Program
                {
                    ProgramID = 1,
                    ProgramName = "Shortcut To Shred",
                }
            };

            return programs;
        }
        private static List<ProgramTemplate> GetProgramTemplates()
        {
            var programTemplates = new List<ProgramTemplate>
            {
                new ProgramTemplate
                {
                    WorkoutID = 1,
                    ProgramID = 1,
                    WorkoutName = "Week 1, Day 1 - Chest, Triceps, Abs"
                },
                new ProgramTemplate
                {
                    WorkoutID = 2,
                    ProgramID = 1,
                    WorkoutName = "Week 1, Day 2 - Shoulders, Legs, Calves"
                },
                new ProgramTemplate
                {
                    WorkoutID = 3,
                    ProgramID = 1,
                    WorkoutName = "Week 1, Day 3 - Back, Traps, Biceps"
                }
            };

            return programTemplates;
        }
        private static List<WorkoutTemplate> GetWorkoutTemplates()
        {
            var workoutTemplates = new List<WorkoutTemplate>
            {
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 1,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 2,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 3,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 4,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 5,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 6,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 1,
                    ExerciseID = 7,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },//------------------------------
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 8,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 9,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 10,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 11,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 12,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 13,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 14,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 2,
                    ExerciseID = 15,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },//------------------------------
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 16,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 17,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 18,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 19,
                    NumberOfSets = 4,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 20,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 21,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 22,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
                new WorkoutTemplate
                {
                    WorkoutID = 3,
                    ExerciseID = 23,
                    NumberOfSets = 3,
                    RepRange = "9-11",
                },
            };

            return workoutTemplates;
        }
        private static List<Exercise> GetExercises()
        {
            var exercises = new List<Exercise>
            {
                new Exercise
                {
                    ExerciseID = 1,
                    ExerciseName = "Barbell Bench Press - Medium Grip",
                },
                new Exercise
                {
                    ExerciseID = 2,
                    ExerciseName = "Incline Dumbbell; Press",
                },
                new Exercise
                {
                    ExerciseID = 3,
                    ExerciseName = "Decline Smith Press",
                },
                new Exercise
                {
                    ExerciseID = 4,
                    ExerciseName = "Dips",
                },
                new Exercise
                {
                    ExerciseID = 5,
                    ExerciseName = "Barbell Bench Press - Close Grip",
                },
                new Exercise
                {
                    ExerciseID = 6,
                    ExerciseName = "Cable Crunch",
                },
                new Exercise
                {
                    ExerciseID = 7,
                    ExerciseName = "Smith Machine Hip Thrust",
                }, //---------------------------------------------------------------------
                new Exercise
                {
                    ExerciseID = 8,
                    ExerciseName = "Barbell Shoulder Press",
                },
                new Exercise
                {
                    ExerciseID = 9,
                    ExerciseName = "Standing Alternating Dumbbell Press",
                },
                new Exercise
                {
                    ExerciseID = 10,
                    ExerciseName = "Smith Machine One-Arm Upright Row",
                },
                new Exercise
                {
                    ExerciseID = 11,
                    ExerciseName = "Barbell Squat",
                },
                new Exercise
                {
                    ExerciseID = 12,
                    ExerciseName = "Barbell Deadlift",
                },
                new Exercise
                {
                    ExerciseID = 13,
                    ExerciseName = "Walking Lunge",
                },
                new Exercise
                {
                    ExerciseID = 14,
                    ExerciseName = "Standing Calf Raises",
                },
                new Exercise
                {
                    ExerciseID = 15,
                    ExerciseName = "Seated Calf Raises",
                },//---------------------------------------------------------------------
                new Exercise
                {
                    ExerciseID = 16,
                    ExerciseName = "Bent Over Barbell Row",
                },
                new Exercise
                {
                    ExerciseID = 17,
                    ExerciseName = "Bent Over Dumbbell Row",
                },
                new Exercise
                {
                    ExerciseID = 18,
                    ExerciseName = "Seated Cable Rows",
                },
                new Exercise
                {
                    ExerciseID = 19,
                    ExerciseName = "Barbell Shrug",
                },
                new Exercise
                {
                    ExerciseID = 20,
                    ExerciseName = "Barbell Curl",
                },
                new Exercise
                {
                    ExerciseID = 21,
                    ExerciseName = "EZ-Bar Preacher Curl",
                },
                new Exercise
                {
                    ExerciseID = 22,
                    ExerciseName = "Reverse Barbell Curl",
                },
                new Exercise
                {
                    ExerciseID = 23,
                    ExerciseName = "Seated Palm-Up Barbell Wrist Curl",
                },
            };

            return exercises;
        }
    }
}