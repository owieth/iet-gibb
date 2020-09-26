namespace Modul104.carFinder
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblCarFinderTitle = new System.Windows.Forms.Label();
            this.combxBrand = new System.Windows.Forms.ComboBox();
            this.combxCategorie = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(99, 198);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(383, 43);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(28, 149);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(517, 43);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // lblCarFinderTitle
            // 
            this.lblCarFinderTitle.AutoSize = true;
            this.lblCarFinderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCarFinderTitle.Font = new System.Drawing.Font("Franklin Gothic Medium", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarFinderTitle.Location = new System.Drawing.Point(140, 9);
            this.lblCarFinderTitle.Name = "lblCarFinderTitle";
            this.lblCarFinderTitle.Size = new System.Drawing.Size(302, 81);
            this.lblCarFinderTitle.TabIndex = 5;
            this.lblCarFinderTitle.Text = "carFinder";
            // 
            // combxBrand
            // 
            this.combxBrand.BackColor = System.Drawing.Color.White;
            this.combxBrand.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combxBrand.FormattingEnabled = true;
            this.combxBrand.Items.AddRange(new object[] {
            "Mercedes - Benz",
            "McLaren",
            "Ferrari",
            "Lamborghini",
            "Rolls Royce",
            "Bentley",
            "Porsche",
            "BMW",
            "Audi"});
            this.combxBrand.Location = new System.Drawing.Point(28, 298);
            this.combxBrand.Name = "combxBrand";
            this.combxBrand.Size = new System.Drawing.Size(229, 32);
            this.combxBrand.TabIndex = 6;
            this.combxBrand.Text = "Marke";
            // 
            // combxCategorie
            // 
            this.combxCategorie.BackColor = System.Drawing.Color.White;
            this.combxCategorie.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combxCategorie.FormattingEnabled = true;
            this.combxCategorie.Items.AddRange(new object[] {
            "SUV"});
            this.combxCategorie.Location = new System.Drawing.Point(316, 298);
            this.combxCategorie.Name = "combxCategorie";
            this.combxCategorie.Size = new System.Drawing.Size(229, 32);
            this.combxCategorie.TabIndex = 7;
            this.combxCategorie.Text = "Kategorie";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Black;
            this.btnFilter.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(99, 346);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(383, 43);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filtern";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Modul104.carFinder.Properties.Resources.amg2;
            this.ClientSize = new System.Drawing.Size(564, 417);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.combxCategorie);
            this.Controls.Add(this.combxBrand);
            this.Controls.Add(this.lblCarFinderTitle);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblCarFinderTitle;
        private System.Windows.Forms.ComboBox combxBrand;
        private System.Windows.Forms.ComboBox combxCategorie;
        private System.Windows.Forms.Button btnFilter;
    }
}

