using ExerciseTracker.Utilites.Factories;
using ExerciseTracker.Utilites.Objects;
using ExerciseTracker.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ExerciseTracker.Member
{
    public partial class Record : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateGrids();
            }
        }

        private void CreateGrids()
        {
            var user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());

            Program userProgram = TrackerAdapter.GeActiveProgramForUser(user);

            GridViewContainer.Rows.Add(TableRowFactory.CreateTableRow(userProgram.Name));
            foreach (Workout workout in userProgram.Workouts)
            {
                if (workout.HasBeenCompleted == false)
                {
                    GridViewContainer.Rows.Add(TableRowFactory.CreateTableRow(workout.Name));
                    foreach (Exercise exercise in workout.Exercises)
                    {
                        GridViewContainer.Rows.Add(TableRowFactory.CreateTableRow(exercise.Name));
                        for (int i = 0; i < exercise.Sets.Keys.Count; i++)
                            GridViewContainer.Rows.Add(TableRowFactory.CreateTableRow(string.Concat("Set ", i + 1), new TextBox() { Text = "Weight X Reps", ToolTip = "Ex. 135x9" }));
                        GridViewContainer.Rows.Add(TableRowFactory.CreateTableRow(new Literal() { Text = "<hr />" }));
                    }

                    break;
                }

            }

        }
    }
}