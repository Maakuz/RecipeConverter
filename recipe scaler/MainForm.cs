using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace recipe_scaler
{
    public partial class MainForm : Form
    {
        const decimal MLINCUP = 236.588237M;
        const decimal GINOZ = 28.3495231M;
        decimal prevPercentage = 100;

        public MainForm()
        {
            InitializeComponent();
            loadItems();
            loadRecipes();
        }

        private void loadItems()
        {
            DBHandler.loadItemFile();

            comboItems.Items.Clear();

            comboItems.Items.AddRange(DBHandler.getRange<Ingredient>().ToArray());
        }

        private void loadRecipes()
        {
            DBHandler.loadRecipeFile();

            comboRecipes.Items.Clear();

            comboRecipes.Items.AddRange(DBHandler.getRange<Recipe>().ToArray());
        }

        private void addItem(string unit)
        {
            textAmount.Text = textAmount.Text.Replace('.', ',');
            if (Double.TryParse(textAmount.Text, out _) && comboItems.Text.Length > 0)
                dataGridView.Rows.Add(comboItems.Text, textAmount.Text, unit);
        }

        private decimal scaleTo100Percentage(decimal value)
        {
            return value / this.prevPercentage * 100M;
        }

        private decimal scaleTo100Percentage(object value)
        {
            return decimal.Parse(value.ToString()) / this.prevPercentage * 100M;
        }

        //Converts between inperial and metric
        private void convertSystem(DataGridViewRow dataGridViewRow)
        {
            string unit = (string)dataGridViewRow.Cells[2].Value;
            decimal val = decimal.Parse(dataGridViewRow.Cells[1].Value.ToString());
            if (unit == "ml")
            {
                dataGridViewRow.Cells[2].Value = "cups";
                dataGridViewRow.Cells[1].Value = Math.Round(val / MLINCUP, 2);
            }

            else if (unit == "cups")
            {
                dataGridViewRow.Cells[2].Value = "ml";
                dataGridViewRow.Cells[1].Value = Math.Round(val * MLINCUP);
            }

            else if (unit == "g")
            {

                dataGridViewRow.Cells[2].Value = "oz";
                dataGridViewRow.Cells[1].Value = Math.Round(val / GINOZ, 2);

            }

            else if (unit == "oz")
            {
                dataGridViewRow.Cells[2].Value = "g";
                dataGridViewRow.Cells[1].Value = Math.Round(val * GINOZ);
            }
        }

        //Converts between g and ml or oz and cups
        private void convertUnit(DataGridViewRow dataGridViewRow)
        {
            decimal weight = DBHandler.GetIngredient(dataGridViewRow.Cells[0].Value.ToString()).weight / 100M;

            if (weight < 0.0001M)
                return;

            string unit = (string)dataGridViewRow.Cells[2].Value;
            bool systemChanged = false;

            if (unit == "cups" || unit == "oz")
            {
                convertSystem(dataGridViewRow);
                unit = (string)dataGridViewRow.Cells[2].Value;

                systemChanged = true;
            }

            decimal val = decimal.Parse(dataGridViewRow.Cells[1].Value.ToString());



            if (unit == "ml")
            {
                dataGridViewRow.Cells[2].Value = "g";
                dataGridViewRow.Cells[1].Value = Math.Round(weight * val, 2);
            }

            else if (unit == "g")
            {
                dataGridViewRow.Cells[2].Value = "ml";
                dataGridViewRow.Cells[1].Value = Math.Round(val * (1 / weight), 2);
            }

            if (systemChanged)
                convertSystem(dataGridViewRow);
        }

        private void btnLiquid_Click(object sender, EventArgs e)
        {
            addItem(btnLiquid.Text);
        }

        private void btnSolid_Click(object sender, EventArgs e)
        {
            addItem(btnSolid.Text);
        }

        private void btnPiece_Click(object sender, EventArgs e)
        {
            addItem("Piece");
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            if (btnSystem.Text == "Metric")
            {
                btnSystem.Text = "Imperial";
                btnLiquid.Text = "cups";
                btnSolid.Text = "oz";

                
            }

            else
            {
                btnSystem.Text = "Metric";
                btnLiquid.Text = "ml";
                btnSolid.Text = "g";

                
            }

            //conversion
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                convertSystem(dataGridViewRow);
            }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                ContextMenu cm = new ContextMenu();
                string unit = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string text = unit == "ml" || unit == "cups" ? "Change to weight" : "Change to volume";

                Action<object, EventArgs> cmChangeUnit = (routedSender, routedArgs) => { cm_clickChangeUnit(routedSender, routedArgs, e.RowIndex); }; 
                cm.MenuItems.Add(new MenuItem(text, new EventHandler(cmChangeUnit)));

                Action<object, EventArgs> cmRemove = (routedSender, routedArgs) => { dataGridView.Rows.RemoveAt(e.RowIndex); };
                cm.MenuItems.Add(new MenuItem("Remove", new EventHandler(cmRemove)));

                //Todo: Maybe make less ugly
                Point cursor = PointToClient(new Point(MousePosition.X - 20, MousePosition.Y - 30));
                cm.Show(dataGridView, cursor);
            }
        }

        private void cm_clickChangeUnit(object sender, EventArgs e, int rowIndex)
        {
            convertUnit(dataGridView.Rows[rowIndex]);
        }

        private void textItem_Enter(object sender, EventArgs e)
        {
            textItem.Text = "";
            textItem.ForeColor = Color.Black;
        }

        private void textItem_Leave(object sender, EventArgs e)
        {
            textItem.Text = "Enter item and press Enter";
            textItem.ForeColor = Color.Gray;
        }

        private void textItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textItem.Text.Length > 0)
            {
                DBHandler.addIngredient(textItem.Text, 0);

                loadItems();

                comboItems.SelectedItem = textItem.Text;

                textItem.Text = "";

                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void btnItemDB_Click(object sender, EventArgs e)
        {
            ItemDB db = new ItemDB();
            db.Show();
        }

        private void numericUpDownScale_ValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                decimal orig = scaleTo100Percentage(row.Cells[1].Value);
                row.Cells[1].Value = Math.Round(orig * this.numericUpDownScale.Value * (decimal)0.01, 2);
            }


            prevPercentage = this.numericUpDownScale.Value;
        }

        private void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            string name = textBoxRecipeName.Text;

            List<Component> components = new List<Component>();
            foreach (DataGridViewRow rows in this.dataGridView.Rows)
            {
                Ingredient ingredient = DBHandler.GetIngredient(rows.Cells[0].Value.ToString());
                components.Add(new Component(ingredient, scaleTo100Percentage(rows.Cells[1].Value), rows.Cells[2].Value.ToString()));
            }

            string desc = textDescription.Text;

            DBHandler.addRecipe(new Recipe(name, components, desc));

            loadRecipes();
        }

        private void btnLoadRecipe_Click(object sender, EventArgs e)
        {
            if (comboRecipes.SelectedIndex == -1)
                return;

            prevPercentage = 100;
            this.numericUpDownScale.Value = 100;

            this.dataGridView.Rows.Clear();

            Recipe recipe = DBHandler.Recipes[comboRecipes.SelectedIndex];

            foreach (Component component in recipe.components)
            {
                this.dataGridView.Rows.Add(component.ingredient.name, component.quantity, component.unit);
            }

            textDescription.Text = recipe.desc;
        }
    }
}
