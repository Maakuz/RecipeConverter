using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_scaler
{
    public partial class ItemDB : Form
    {
        public ItemDB()
        {
            InitializeComponent();
        }

        private void ItemDB_Load(object sender, EventArgs e)
        {

        }

        private void ItemDB_Shown(object sender, EventArgs e)
        {
            comboBoxIngredients.Items.Clear();
            comboBoxIngredients.Items.AddRange(DBHandler.getRange<Ingredient>().ToArray());
        }

        private void comboBoxIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWeight.Text = DBHandler.GetIngredient(comboBoxIngredients.SelectedItem.ToString()).weight.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxIngredients.SelectedIndex == -1)
                return;

            decimal modifier = 100 / numericUpDownAmount.Value;

            DBHandler.updateIngredient(comboBoxIngredients.SelectedItem.ToString(), modifier * numericUpDownWeight.Value);
            labelWeight.Text = DBHandler.GetIngredient(comboBoxIngredients.SelectedItem.ToString()).weight.ToString();
        }
    }
}
