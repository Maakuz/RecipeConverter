
namespace recipe_scaler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLiquid = new System.Windows.Forms.Button();
            this.textItem = new System.Windows.Forms.TextBox();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.btnSolid = new System.Windows.Forms.Button();
            this.btnSystem = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPiece = new System.Windows.Forms.Button();
            this.labelWishlist = new System.Windows.Forms.Label();
            this.comboItems = new System.Windows.Forms.ComboBox();
            this.btnItemDB = new System.Windows.Forms.Button();
            this.labelScale = new System.Windows.Forms.Label();
            this.numericUpDownScale = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLiquid
            // 
            this.btnLiquid.Location = new System.Drawing.Point(333, 10);
            this.btnLiquid.Name = "btnLiquid";
            this.btnLiquid.Size = new System.Drawing.Size(75, 23);
            this.btnLiquid.TabIndex = 0;
            this.btnLiquid.Text = "ml";
            this.btnLiquid.UseVisualStyleBackColor = true;
            this.btnLiquid.Click += new System.EventHandler(this.btnLiquid_Click);
            // 
            // textItem
            // 
            this.textItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textItem.Location = new System.Drawing.Point(336, 244);
            this.textItem.Name = "textItem";
            this.textItem.Size = new System.Drawing.Size(178, 20);
            this.textItem.TabIndex = 1;
            this.textItem.Text = "Enter item and press Enter";
            this.textItem.Enter += new System.EventHandler(this.textItem_Enter);
            this.textItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textItem_KeyDown);
            this.textItem.Leave += new System.EventHandler(this.textItem_Leave);
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(257, 12);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(70, 20);
            this.textAmount.TabIndex = 2;
            // 
            // btnSolid
            // 
            this.btnSolid.Location = new System.Drawing.Point(333, 39);
            this.btnSolid.Name = "btnSolid";
            this.btnSolid.Size = new System.Drawing.Size(75, 23);
            this.btnSolid.TabIndex = 3;
            this.btnSolid.Text = "g";
            this.btnSolid.UseVisualStyleBackColor = true;
            this.btnSolid.Click += new System.EventHandler(this.btnSolid_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.Location = new System.Drawing.Point(439, 10);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(75, 23);
            this.btnSystem.TabIndex = 4;
            this.btnSystem.Text = "Metric";
            this.btnSystem.UseVisualStyleBackColor = true;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.amount,
            this.unit});
            this.dataGridView.Location = new System.Drawing.Point(12, 39);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(315, 448);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 130;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 50;
            // 
            // unit
            // 
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 60;
            // 
            // btnPiece
            // 
            this.btnPiece.Location = new System.Drawing.Point(333, 68);
            this.btnPiece.Name = "btnPiece";
            this.btnPiece.Size = new System.Drawing.Size(75, 23);
            this.btnPiece.TabIndex = 6;
            this.btnPiece.Text = "Piece";
            this.btnPiece.UseVisualStyleBackColor = true;
            this.btnPiece.Click += new System.EventHandler(this.btnPiece_Click);
            // 
            // labelWishlist
            // 
            this.labelWishlist.AutoSize = true;
            this.labelWishlist.Location = new System.Drawing.Point(333, 128);
            this.labelWishlist.Name = "labelWishlist";
            this.labelWishlist.Size = new System.Drawing.Size(143, 52);
            this.labelWishlist.TabIndex = 7;
            this.labelWishlist.Text = "Saker jag önskar den gjorde:\r\nvolym till vikt\r\ntog bort ingredienser\r\nsparade rec" +
    "ept\r\n";
            // 
            // comboItems
            // 
            this.comboItems.BackColor = System.Drawing.SystemColors.Window;
            this.comboItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItems.FormattingEnabled = true;
            this.comboItems.Location = new System.Drawing.Point(12, 12);
            this.comboItems.Name = "comboItems";
            this.comboItems.Size = new System.Drawing.Size(239, 21);
            this.comboItems.Sorted = true;
            this.comboItems.TabIndex = 9;
            // 
            // btnItemDB
            // 
            this.btnItemDB.Location = new System.Drawing.Point(336, 270);
            this.btnItemDB.Name = "btnItemDB";
            this.btnItemDB.Size = new System.Drawing.Size(75, 23);
            this.btnItemDB.TabIndex = 10;
            this.btnItemDB.Text = "Item DB";
            this.btnItemDB.UseVisualStyleBackColor = true;
            this.btnItemDB.Click += new System.EventHandler(this.btnItemDB_Click);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(336, 338);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(94, 13);
            this.labelScale.TabIndex = 11;
            this.labelScale.Text = "Scale, percentage";
            // 
            // numericUpDownScale
            // 
            this.numericUpDownScale.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScale.Location = new System.Drawing.Point(339, 355);
            this.numericUpDownScale.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownScale.Name = "numericUpDownScale";
            this.numericUpDownScale.Size = new System.Drawing.Size(175, 20);
            this.numericUpDownScale.TabIndex = 12;
            this.numericUpDownScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownScale.ValueChanged += new System.EventHandler(this.numericUpDownScale_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 516);
            this.Controls.Add(this.numericUpDownScale);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.btnItemDB);
            this.Controls.Add(this.comboItems);
            this.Controls.Add(this.labelWishlist);
            this.Controls.Add(this.btnPiece);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnSystem);
            this.Controls.Add(this.btnSolid);
            this.Controls.Add(this.textAmount);
            this.Controls.Add(this.textItem);
            this.Controls.Add(this.btnLiquid);
            this.Name = "MainForm";
            this.Text = "Recipe";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLiquid;
        private System.Windows.Forms.TextBox textItem;
        private System.Windows.Forms.TextBox textAmount;
        private System.Windows.Forms.Button btnSolid;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnPiece;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.Label labelWishlist;
        private System.Windows.Forms.ComboBox comboItems;
        private System.Windows.Forms.Button btnItemDB;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.NumericUpDown numericUpDownScale;
    }
}

