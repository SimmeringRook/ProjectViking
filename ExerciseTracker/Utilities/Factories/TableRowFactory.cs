using System.Collections;
using System.Web.UI.WebControls;

namespace ExerciseTracker.Utilites.Factories
{
    public class TableRowFactory
    {
        public static TableRow CreateTableRow(params object[] args)
        {
            TableRow templateRow = new TableRow();
            foreach (object argument in args)
            {
                if (argument is string)
                    templateRow.Cells.Add(CreateCellWithControl(new Label() { Text = (argument as string) }));
                else if (argument is IDictionary)
                    templateRow.Cells.Add(CreateCellWithControl(new GridView() { DataSource = (argument as IDictionary).Values }));
                else if (argument is ICollection)
                    templateRow.Cells.Add(CreateCellWithControl(new DropDownList() { DataSource = (argument as ICollection) }));
                else if (argument is TextBox)
                    templateRow.Cells.Add(CreateCellWithControl(argument as TextBox));
                else if (argument is Literal)
                    templateRow.Cells.Add(CreateCellWithControl(argument as Literal));
            }
            return templateRow;
        }

        private static TableCell CreateCellWithControl(GridView gridView)
        {
            TableCell templateCell = new TableCell();
            templateCell.Controls.Add(gridView);
            gridView.DataBind();
            return templateCell;
        }

        private static TableCell CreateCellWithControl(DropDownList dropDownList)
        {
            TableCell templateCell = new TableCell();
            templateCell.Controls.Add(dropDownList);
            dropDownList.DataBind();
            return templateCell;
        }

        private static TableCell CreateCellWithControl(TextBox textbox)
        {
            TableCell templateCell = new TableCell();
            templateCell.Controls.Add(textbox);
            return templateCell;
        }

        private static TableCell CreateCellWithControl(Literal literal)
        {
            TableCell templateCell = new TableCell();
            templateCell.Controls.Add(literal);
            return templateCell;
        }

        private static TableCell CreateCellWithControl(Label label)
        {
            TableCell templateCell = new TableCell();
            templateCell.Controls.Add(label);
            return templateCell;
        }
    }
}
