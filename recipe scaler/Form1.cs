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
    public partial class Form1 : Form
    {

        const double MLINCUP = 236.588237;
        const double GINOZ = 28.3495231;

        public Form1()
        {
            InitializeComponent();
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

        private void addItem(string unit)
        {
            textAmount.Text = textAmount.Text.Replace('.',',');
            if (Double.TryParse(textAmount.Text, out _))
                dataGridView.Rows.Add(textItem.Text, textAmount.Text, unit);
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
    }
}
