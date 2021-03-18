
namespace recipe_scaler
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.textItem.Location = new System.Drawing.Point(12, 12);
            this.textItem.Name = "textItem";
            this.textItem.Size = new System.Drawing.Size(239, 20);
            this.textItem.TabIndex = 1;
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
            this.btnSystem.Location = new System.Drawing.Point(431, 10);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 65);
            this.label1.TabIndex = 7;
            this.label1.Text = "Saker jag önskar den gjorde:\r\navrundade någorlunda.\r\nskalade recept\r\nsparade ingr" +
    "edienser\r\nsparade recept\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPiece);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnSystem);
            this.Controls.Add(this.btnSolid);
            this.Controls.Add(this.textAmount);
            this.Controls.Add(this.textItem);
            this.Controls.Add(this.btnLiquid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
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
        private System.Windows.Forms.Label label1;
    }
}

