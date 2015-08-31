namespace Lab6 {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.comboBoxCategorii = new System.Windows.Forms.ComboBox();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.cmd = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.labelCategorii = new System.Windows.Forms.Label();
			this.labelPreparate = new System.Windows.Forms.Label();
			this.listBoxPreparate = new System.Windows.Forms.ListBox();
			this.labelNumeP = new System.Windows.Forms.Label();
			this.labelPretP = new System.Windows.Forms.Label();
			this.labelTimpP = new System.Windows.Forms.Label();
			this.textBoxNumeP = new System.Windows.Forms.TextBox();
			this.textBoxPretP = new System.Windows.Forms.TextBox();
			this.textBoxTimpP = new System.Windows.Forms.TextBox();
			this.groupBoxInfos = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listViewReteta = new System.Windows.Forms.ListView();
			this.CHIngredient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CHCantitatea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonAddPr = new System.Windows.Forms.Button();
			this.buttonDelPr = new System.Windows.Forms.Button();
			this.buttonAddIn = new System.Windows.Forms.Button();
			this.buttonDelIn = new System.Windows.Forms.Button();
			this.labelUnit = new System.Windows.Forms.Label();
			this.textBoxUnit = new System.Windows.Forms.TextBox();
			this.labelLPr = new System.Windows.Forms.Label();
			this.comboBoxLPr = new System.Windows.Forms.ComboBox();
			this.labelNumeIn = new System.Windows.Forms.Label();
			this.textBoxNumeIn = new System.Windows.Forms.TextBox();
			this.groupBoxIngr = new System.Windows.Forms.GroupBox();
			this.textBoxCantitate = new System.Windows.Forms.TextBox();
			this.labelCantitatea = new System.Windows.Forms.Label();
			this.buttonModifPr = new System.Windows.Forms.Button();
			this.buttonModifIn = new System.Windows.Forms.Button();
			this.buttonAddInR = new System.Windows.Forms.Button();
			this.buttonDelFromR = new System.Windows.Forms.Button();
			this.groupBoxInfos.SuspendLayout();
			this.groupBoxIngr.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxCategorii
			// 
			this.comboBoxCategorii.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxCategorii.FormattingEnabled = true;
			this.comboBoxCategorii.Location = new System.Drawing.Point(30, 68);
			this.comboBoxCategorii.Name = "comboBoxCategorii";
			this.comboBoxCategorii.Size = new System.Drawing.Size(296, 33);
			this.comboBoxCategorii.TabIndex = 1;
			this.comboBoxCategorii.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategorii_SelectedIndexChanged);
			// 
			// conn
			// 
			this.conn.ConnectionString = "Data Source=ANCA\\ANCA;Initial Catalog=Lab6;Integrated Security=True";
			this.conn.FireInfoMessageEventOnUserErrors = false;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "Data Source=ANCA\\ANCA;Initial Catalog=Lab6;Integrated Security=True";
			this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
			// 
			// labelCategorii
			// 
			this.labelCategorii.AutoSize = true;
			this.labelCategorii.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCategorii.Location = new System.Drawing.Point(27, 28);
			this.labelCategorii.Name = "labelCategorii";
			this.labelCategorii.Size = new System.Drawing.Size(113, 25);
			this.labelCategorii.TabIndex = 2;
			this.labelCategorii.Text = "Categories:";
			// 
			// labelPreparate
			// 
			this.labelPreparate.AutoSize = true;
			this.labelPreparate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPreparate.Location = new System.Drawing.Point(29, 133);
			this.labelPreparate.Name = "labelPreparate";
			this.labelPreparate.Size = new System.Drawing.Size(63, 25);
			this.labelPreparate.TabIndex = 3;
			this.labelPreparate.Text = "Food:";
			// 
			// listBoxPreparate
			// 
			this.listBoxPreparate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxPreparate.FormattingEnabled = true;
			this.listBoxPreparate.ItemHeight = 25;
			this.listBoxPreparate.Location = new System.Drawing.Point(30, 170);
			this.listBoxPreparate.Name = "listBoxPreparate";
			this.listBoxPreparate.Size = new System.Drawing.Size(384, 504);
			this.listBoxPreparate.TabIndex = 4;
			this.listBoxPreparate.SelectedIndexChanged += new System.EventHandler(this.listBoxPreparate_SelectedIndexChanged);
			// 
			// labelNumeP
			// 
			this.labelNumeP.AutoSize = true;
			this.labelNumeP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumeP.Location = new System.Drawing.Point(6, 43);
			this.labelNumeP.Name = "labelNumeP";
			this.labelNumeP.Size = new System.Drawing.Size(64, 25);
			this.labelNumeP.TabIndex = 6;
			this.labelNumeP.Text = "Name";
			// 
			// labelPretP
			// 
			this.labelPretP.AutoSize = true;
			this.labelPretP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPretP.Location = new System.Drawing.Point(6, 84);
			this.labelPretP.Name = "labelPretP";
			this.labelPretP.Size = new System.Drawing.Size(56, 25);
			this.labelPretP.TabIndex = 7;
			this.labelPretP.Text = "Price";
			// 
			// labelTimpP
			// 
			this.labelTimpP.AutoSize = true;
			this.labelTimpP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTimpP.Location = new System.Drawing.Point(6, 120);
			this.labelTimpP.Name = "labelTimpP";
			this.labelTimpP.Size = new System.Drawing.Size(153, 25);
			this.labelTimpP.TabIndex = 8;
			this.labelTimpP.Text = "Preparation time";
			// 
			// textBoxNumeP
			// 
			this.textBoxNumeP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxNumeP.Location = new System.Drawing.Point(76, 43);
			this.textBoxNumeP.Name = "textBoxNumeP";
			this.textBoxNumeP.Size = new System.Drawing.Size(379, 30);
			this.textBoxNumeP.TabIndex = 11;
			// 
			// textBoxPretP
			// 
			this.textBoxPretP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPretP.Location = new System.Drawing.Point(59, 79);
			this.textBoxPretP.Name = "textBoxPretP";
			this.textBoxPretP.Size = new System.Drawing.Size(396, 30);
			this.textBoxPretP.TabIndex = 12;
			// 
			// textBoxTimpP
			// 
			this.textBoxTimpP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxTimpP.Location = new System.Drawing.Point(157, 115);
			this.textBoxTimpP.Name = "textBoxTimpP";
			this.textBoxTimpP.Size = new System.Drawing.Size(298, 30);
			this.textBoxTimpP.TabIndex = 13;
			// 
			// groupBoxInfos
			// 
			this.groupBoxInfos.Controls.Add(this.textBoxTimpP);
			this.groupBoxInfos.Controls.Add(this.textBoxPretP);
			this.groupBoxInfos.Controls.Add(this.textBoxNumeP);
			this.groupBoxInfos.Controls.Add(this.labelTimpP);
			this.groupBoxInfos.Controls.Add(this.labelPretP);
			this.groupBoxInfos.Controls.Add(this.labelNumeP);
			this.groupBoxInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxInfos.Location = new System.Drawing.Point(424, 28);
			this.groupBoxInfos.Name = "groupBoxInfos";
			this.groupBoxInfos.Size = new System.Drawing.Size(474, 177);
			this.groupBoxInfos.TabIndex = 14;
			this.groupBoxInfos.TabStop = false;
			this.groupBoxInfos.Text = "Infos";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(420, 223);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 25);
			this.label1.TabIndex = 15;
			this.label1.Text = "Recipe";
			// 
			// listViewReteta
			// 
			this.listViewReteta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHIngredient,
            this.CHCantitatea});
			this.listViewReteta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listViewReteta.FullRowSelect = true;
			this.listViewReteta.GridLines = true;
			this.listViewReteta.HideSelection = false;
			this.listViewReteta.Location = new System.Drawing.Point(449, 251);
			this.listViewReteta.MultiSelect = false;
			this.listViewReteta.Name = "listViewReteta";
			this.listViewReteta.Size = new System.Drawing.Size(472, 214);
			this.listViewReteta.TabIndex = 16;
			this.listViewReteta.UseCompatibleStateImageBehavior = false;
			this.listViewReteta.View = System.Windows.Forms.View.Details;
			this.listViewReteta.SelectedIndexChanged += new System.EventHandler(this.listViewReteta_SelectedIndexChanged);
			// 
			// CHIngredient
			// 
			this.CHIngredient.Text = "Ingredient";
			this.CHIngredient.Width = 303;
			// 
			// CHCantitatea
			// 
			this.CHCantitatea.Text = "Quantity";
			this.CHCantitatea.Width = 163;
			// 
			// buttonAddPr
			// 
			this.buttonAddPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAddPr.Location = new System.Drawing.Point(937, 37);
			this.buttonAddPr.Name = "buttonAddPr";
			this.buttonAddPr.Size = new System.Drawing.Size(191, 49);
			this.buttonAddPr.TabIndex = 14;
			this.buttonAddPr.Text = "Add food";
			this.buttonAddPr.UseVisualStyleBackColor = true;
			this.buttonAddPr.Click += new System.EventHandler(this.buttonAddPr_Click);
			// 
			// buttonDelPr
			// 
			this.buttonDelPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDelPr.Location = new System.Drawing.Point(937, 107);
			this.buttonDelPr.Name = "buttonDelPr";
			this.buttonDelPr.Size = new System.Drawing.Size(191, 49);
			this.buttonDelPr.TabIndex = 15;
			this.buttonDelPr.Text = "Delete food";
			this.buttonDelPr.UseVisualStyleBackColor = true;
			this.buttonDelPr.Click += new System.EventHandler(this.buttonDelPr_Click);
			// 
			// buttonAddIn
			// 
			this.buttonAddIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAddIn.Location = new System.Drawing.Point(927, 517);
			this.buttonAddIn.Name = "buttonAddIn";
			this.buttonAddIn.Size = new System.Drawing.Size(201, 49);
			this.buttonAddIn.TabIndex = 19;
			this.buttonAddIn.Text = "Add Ingredient";
			this.buttonAddIn.UseVisualStyleBackColor = true;
			this.buttonAddIn.Click += new System.EventHandler(this.buttonAddIn_Click);
			// 
			// buttonDelIn
			// 
			this.buttonDelIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDelIn.Location = new System.Drawing.Point(927, 572);
			this.buttonDelIn.Name = "buttonDelIn";
			this.buttonDelIn.Size = new System.Drawing.Size(201, 49);
			this.buttonDelIn.TabIndex = 20;
			this.buttonDelIn.Text = "Delete Ingredient";
			this.buttonDelIn.UseVisualStyleBackColor = true;
			this.buttonDelIn.Click += new System.EventHandler(this.buttonDelIn_Click);
			// 
			// labelUnit
			// 
			this.labelUnit.AutoSize = true;
			this.labelUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUnit.Location = new System.Drawing.Point(6, 76);
			this.labelUnit.Name = "labelUnit";
			this.labelUnit.Size = new System.Drawing.Size(46, 25);
			this.labelUnit.TabIndex = 21;
			this.labelUnit.Text = "Unit";
			// 
			// textBoxUnit
			// 
			this.textBoxUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxUnit.Location = new System.Drawing.Point(182, 71);
			this.textBoxUnit.Name = "textBoxUnit";
			this.textBoxUnit.Size = new System.Drawing.Size(271, 30);
			this.textBoxUnit.TabIndex = 18;
			// 
			// labelLPr
			// 
			this.labelLPr.AutoSize = true;
			this.labelLPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLPr.Location = new System.Drawing.Point(8, 115);
			this.labelLPr.Name = "labelLPr";
			this.labelLPr.Size = new System.Drawing.Size(122, 25);
			this.labelLPr.TabIndex = 23;
			this.labelLPr.Text = "List of foods:";
			// 
			// comboBoxLPr
			// 
			this.comboBoxLPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxLPr.FormattingEnabled = true;
			this.comboBoxLPr.Location = new System.Drawing.Point(161, 107);
			this.comboBoxLPr.Name = "comboBoxLPr";
			this.comboBoxLPr.Size = new System.Drawing.Size(292, 33);
			this.comboBoxLPr.TabIndex = 24;
			// 
			// labelNumeIn
			// 
			this.labelNumeIn.AutoSize = true;
			this.labelNumeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumeIn.Location = new System.Drawing.Point(8, 40);
			this.labelNumeIn.Name = "labelNumeIn";
			this.labelNumeIn.Size = new System.Drawing.Size(64, 25);
			this.labelNumeIn.TabIndex = 25;
			this.labelNumeIn.Text = "Name";
			// 
			// textBoxNumeIn
			// 
			this.textBoxNumeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxNumeIn.Location = new System.Drawing.Point(87, 35);
			this.textBoxNumeIn.Name = "textBoxNumeIn";
			this.textBoxNumeIn.Size = new System.Drawing.Size(366, 30);
			this.textBoxNumeIn.TabIndex = 17;
			// 
			// groupBoxIngr
			// 
			this.groupBoxIngr.Controls.Add(this.textBoxCantitate);
			this.groupBoxIngr.Controls.Add(this.labelCantitatea);
			this.groupBoxIngr.Controls.Add(this.textBoxNumeIn);
			this.groupBoxIngr.Controls.Add(this.labelNumeIn);
			this.groupBoxIngr.Controls.Add(this.comboBoxLPr);
			this.groupBoxIngr.Controls.Add(this.labelLPr);
			this.groupBoxIngr.Controls.Add(this.textBoxUnit);
			this.groupBoxIngr.Controls.Add(this.labelUnit);
			this.groupBoxIngr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxIngr.Location = new System.Drawing.Point(424, 480);
			this.groupBoxIngr.Name = "groupBoxIngr";
			this.groupBoxIngr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBoxIngr.Size = new System.Drawing.Size(473, 194);
			this.groupBoxIngr.TabIndex = 27;
			this.groupBoxIngr.TabStop = false;
			this.groupBoxIngr.Text = "Ingredient";
			// 
			// textBoxCantitate
			// 
			this.textBoxCantitate.Location = new System.Drawing.Point(157, 146);
			this.textBoxCantitate.Name = "textBoxCantitate";
			this.textBoxCantitate.Size = new System.Drawing.Size(296, 30);
			this.textBoxCantitate.TabIndex = 24;
			this.textBoxCantitate.Visible = false;
			this.textBoxCantitate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCantitate_KeyDown);
			// 
			// labelCantitatea
			// 
			this.labelCantitatea.AutoSize = true;
			this.labelCantitatea.Location = new System.Drawing.Point(8, 151);
			this.labelCantitatea.Name = "labelCantitatea";
			this.labelCantitatea.Size = new System.Drawing.Size(85, 25);
			this.labelCantitatea.TabIndex = 27;
			this.labelCantitatea.Text = "Quantity";
			this.labelCantitatea.Visible = false;
			// 
			// buttonModifPr
			// 
			this.buttonModifPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonModifPr.Location = new System.Drawing.Point(937, 170);
			this.buttonModifPr.Name = "buttonModifPr";
			this.buttonModifPr.Size = new System.Drawing.Size(191, 49);
			this.buttonModifPr.TabIndex = 16;
			this.buttonModifPr.Text = "Update food";
			this.buttonModifPr.UseVisualStyleBackColor = true;
			this.buttonModifPr.Click += new System.EventHandler(this.buttonModifPr_Click);
			// 
			// buttonModifIn
			// 
			this.buttonModifIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonModifIn.Location = new System.Drawing.Point(927, 627);
			this.buttonModifIn.Name = "buttonModifIn";
			this.buttonModifIn.Size = new System.Drawing.Size(201, 49);
			this.buttonModifIn.TabIndex = 21;
			this.buttonModifIn.Text = "Update Ingredient";
			this.buttonModifIn.UseVisualStyleBackColor = true;
			this.buttonModifIn.Click += new System.EventHandler(this.buttonModifIn_Click);
			// 
			// buttonAddInR
			// 
			this.buttonAddInR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAddInR.Location = new System.Drawing.Point(927, 284);
			this.buttonAddInR.Name = "buttonAddInR";
			this.buttonAddInR.Size = new System.Drawing.Size(201, 69);
			this.buttonAddInR.TabIndex = 22;
			this.buttonAddInR.Text = "Add ingredient to recipe";
			this.buttonAddInR.UseVisualStyleBackColor = true;
			this.buttonAddInR.Click += new System.EventHandler(this.buttonAddInR_Click);
			// 
			// buttonDelFromR
			// 
			this.buttonDelFromR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDelFromR.Location = new System.Drawing.Point(927, 359);
			this.buttonDelFromR.Name = "buttonDelFromR";
			this.buttonDelFromR.Size = new System.Drawing.Size(201, 69);
			this.buttonDelFromR.TabIndex = 23;
			this.buttonDelFromR.Text = "Delete ingredient from recipe";
			this.buttonDelFromR.UseVisualStyleBackColor = true;
			this.buttonDelFromR.Click += new System.EventHandler(this.buttonDelFromR_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1140, 688);
			this.Controls.Add(this.buttonDelFromR);
			this.Controls.Add(this.buttonAddInR);
			this.Controls.Add(this.buttonModifIn);
			this.Controls.Add(this.buttonModifPr);
			this.Controls.Add(this.groupBoxIngr);
			this.Controls.Add(this.buttonDelIn);
			this.Controls.Add(this.buttonAddIn);
			this.Controls.Add(this.listViewReteta);
			this.Controls.Add(this.buttonDelPr);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonAddPr);
			this.Controls.Add(this.groupBoxInfos);
			this.Controls.Add(this.listBoxPreparate);
			this.Controls.Add(this.labelPreparate);
			this.Controls.Add(this.labelCategorii);
			this.Controls.Add(this.comboBoxCategorii);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.groupBoxInfos.ResumeLayout(false);
			this.groupBoxInfos.PerformLayout();
			this.groupBoxIngr.ResumeLayout(false);
			this.groupBoxIngr.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxCategorii;
		private System.Data.SqlClient.SqlConnection conn;
		private System.Data.SqlClient.SqlCommand cmd;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Windows.Forms.Label labelCategorii;
		private System.Windows.Forms.Label labelPreparate;
		private System.Windows.Forms.ListBox listBoxPreparate;
		private System.Windows.Forms.Label labelNumeP;
		private System.Windows.Forms.Label labelPretP;
		private System.Windows.Forms.Label labelTimpP;
		private System.Windows.Forms.TextBox textBoxNumeP;
		private System.Windows.Forms.TextBox textBoxPretP;
		private System.Windows.Forms.TextBox textBoxTimpP;
		private System.Windows.Forms.GroupBox groupBoxInfos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listViewReteta;
		private System.Windows.Forms.ColumnHeader CHIngredient;
		private System.Windows.Forms.ColumnHeader CHCantitatea;
		private System.Windows.Forms.Button buttonAddPr;
		private System.Windows.Forms.Button buttonDelPr;
		private System.Windows.Forms.Button buttonAddIn;
		private System.Windows.Forms.Button buttonDelIn;
		private System.Windows.Forms.Label labelUnit;
		private System.Windows.Forms.TextBox textBoxUnit;
		private System.Windows.Forms.Label labelLPr;
		private System.Windows.Forms.ComboBox comboBoxLPr;
		private System.Windows.Forms.Label labelNumeIn;
		private System.Windows.Forms.TextBox textBoxNumeIn;
		private System.Windows.Forms.GroupBox groupBoxIngr;
		private System.Windows.Forms.Button buttonModifPr;
		private System.Windows.Forms.Button buttonModifIn;
		private System.Windows.Forms.Button buttonAddInR;
		private System.Windows.Forms.Button buttonDelFromR;
		private System.Windows.Forms.TextBox textBoxCantitate;
		private System.Windows.Forms.Label labelCantitatea;
	}
}

