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
    }
}
