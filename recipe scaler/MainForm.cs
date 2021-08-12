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
        struct Component
        {
            public string name;
            public decimal quantity;
            public string unit;

            public Component(string name, decimal quantity, string unit)
            {
                this.name = name;
                this.quantity = quantity;
                this.unit = unit;
            }
        }

        struct Recipe
        {
            public string name;
            public List<Component> ingredients;
            public string desc;

            public Recipe(string name, List<Component> ingredients, string desc)
            {
                this.name = name;
                this.ingredients = ingredients;
                this.desc = desc;
            }
        }

        const double MLINCUP = 236.588237;
        const double GINOZ = 28.3495231;
        const string ITEMSFILE = "items.db";
        const string RECIPEFILE = "Recipes.db";
        readonly Encoding encoding = Encoding.UTF8;
        decimal prevPercentage = 100;



        List<Recipe> recipes = new List<Recipe>();

        public MainForm()
        {
            InitializeComponent();
            loadItemFile();
            loadRecipeFile();
        }

        private void loadItemFile()
        {
            if (!File.Exists(ITEMSFILE))
                return;

            StreamReader sr = new StreamReader(ITEMSFILE, encoding);

            string item = sr.ReadLine();
            List<string> items = new List<string>();
            List<int> weights = new List<int>();
            while (item != null)
            {
                string[] strings = item.Split(';');

                items.Add(strings[0]);
                weights.Add(int.Parse(strings[1]));
                item = sr.ReadLine();
            }
            sr.Close();

            comboItems.Items.Clear();
            comboItems.Items.AddRange(items.ToArray());
        }

        private void loadRecipeFile()
        {
            if (!File.Exists(RECIPEFILE))
                return;

            recipes.Clear();
            StreamReader sr = new StreamReader(RECIPEFILE, encoding);

            string item = sr.ReadLine();
            while (item != null)
            {
                string name = item;

                item = sr.ReadLine();
                List<Component> ingredients = new List<Component>();
                while (item != "[ITEMEND]")
                {
                    string[] strings = item.Split(';');

                    ingredients.Add(new Component(strings[0], decimal.Parse(strings[1]), strings[2]));
                    item = sr.ReadLine();
                }

                item = sr.ReadLine();
                string desc = "";
                while (item != "[END]")
                {
                    desc += item + "\r\n";
                    item = sr.ReadLine();
                }

                 desc = desc.Substring(0, desc.Length - 2);

                this.recipes.Add(new Recipe(name, ingredients, desc));

                
                item = sr.ReadLine();
            }
            sr.Close();

            comboRecipes.Items.Clear();

            List<string> range = new List<string>();
            foreach (Recipe recipe in recipes)
            {
                range.Add(recipe.name);
            }

            comboRecipes.Items.AddRange(range.ToArray());
        }

        private void addItem(string unit)
        {
            textAmount.Text = textAmount.Text.Replace('.', ',');
            if (Double.TryParse(textAmount.Text, out _) && comboItems.Text.Length > 0)
                dataGridView.Rows.Add(comboItems.Text, textAmount.Text, unit);
        }

        private decimal scaleTo100Percentage(decimal value)
        {
            return value / this.prevPercentage * 100;
        }

        private decimal scaleTo100Percentage(object value)
        {
            return decimal.Parse(value.ToString()) / this.prevPercentage * 100;
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
                string unit = (string)dataGridViewRow.Cells[2].Value;
                double val = Double.Parse(dataGridViewRow.Cells[1].Value.ToString());
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
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);

                textItem.Text = e.RowIndex.ToString();
            }
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
                StreamWriter sw = new StreamWriter(ITEMSFILE, true, encoding);

                sw.WriteLine(textItem.Text + ";0");
                sw.Close();
                loadItemFile();

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
            StreamWriter sw = new StreamWriter(RECIPEFILE, true, encoding);
            sw.WriteLine(textBoxRecipeName.Text);

            foreach (DataGridViewRow rows in this.dataGridView.Rows)
            {
                sw.WriteLine(rows.Cells[0].Value + ";" + scaleTo100Percentage(rows.Cells[1].Value) + ";" + rows.Cells[2].Value + ";");
            }
            
            sw.WriteLine("[ITEMEND]");

            sw.WriteLine(textDescription.Text);

            sw.WriteLine("[END]");
            sw.Close();

            loadRecipeFile();
        }

        private void btnLoadRecipe_Click(object sender, EventArgs e)
        {
            if (comboRecipes.SelectedIndex == -1)
                return;

            prevPercentage = 100;
            this.numericUpDownScale.Value = 100;

            this.dataGridView.Rows.Clear();

            foreach (Component component in this.recipes[comboRecipes.SelectedIndex].ingredients)
            {
                this.dataGridView.Rows.Add(component.name, component.quantity, component.unit);
            }

            textDescription.Text = this.recipes[comboRecipes.SelectedIndex].desc;
        }
    }
}
