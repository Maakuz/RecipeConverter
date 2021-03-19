using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace recipe_scaler
{
    public partial class Form1 : Form
    {

        const double MLINCUP = 236.588237;
        const double GINOZ = 28.3495231;
        const string ITEMSFILE = "items.db";
        Encoding encoding = Encoding.UTF8;

        public Form1()
        {
            InitializeComponent();
            loadFiles();
        }

        private void loadFiles()
        {
            if (!File.Exists(ITEMSFILE))
                return;

            StreamReader sr = new StreamReader(ITEMSFILE, encoding);

            string item = sr.ReadLine();
            List<string> items = new List<string>();
            while (item != null)
            {
                items.Add(item);
                item = sr.ReadLine();
            }
            sr.Close();

            comboItems.Items.Clear();
            comboItems.Items.AddRange(items.ToArray());

        }

        private void addItem(string unit)
        {
            textAmount.Text = textAmount.Text.Replace('.', ',');
            if (Double.TryParse(textAmount.Text, out _) && comboItems.Text.Length > 0)
                dataGridView.Rows.Add(comboItems.Text, textAmount.Text, unit);
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
                string val = (string)dataGridViewRow.Cells[2].Value;
                if (val == "ml")
                {
                    dataGridViewRow.Cells[2].Value = "cups";
                    dataGridViewRow.Cells[1].Value = Double.Parse(dataGridViewRow.Cells[1].Value.ToString()) / MLINCUP;
                }

                else if (val == "cups")
                {
                    dataGridViewRow.Cells[2].Value = "ml";
                    dataGridViewRow.Cells[1].Value = Double.Parse(dataGridViewRow.Cells[1].Value.ToString()) * MLINCUP;
                }

                else if (val == "g")
                {
                    dataGridViewRow.Cells[2].Value = "oz";
                    dataGridViewRow.Cells[1].Value = Double.Parse(dataGridViewRow.Cells[1].Value.ToString()) / GINOZ;
                }

                else if (val == "oz")
                {
                    dataGridViewRow.Cells[2].Value = "g";
                    dataGridViewRow.Cells[1].Value = Double.Parse(dataGridViewRow.Cells[1].Value.ToString()) * GINOZ;
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

        private void textItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textItem.Text.Length > 0)
            {
                StreamWriter sw = new StreamWriter(ITEMSFILE, true, encoding);

                sw.WriteLine(textItem.Text);
                sw.Close();
                loadFiles();

                comboItems.SelectedItem = textItem.Text;

                textItem.Text = "";

                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }
    }
}
