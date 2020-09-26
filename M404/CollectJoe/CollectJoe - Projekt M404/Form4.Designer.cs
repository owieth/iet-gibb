namespace CollectJoe___Projekt_M404
{
    partial class frmEditScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditScore));
            this.lblWrite = new System.Windows.Forms.Label();
            this.lblShowScore = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtYourName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWrite
            // 
            this.lblWrite.AutoSize = true;
            this.lblWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrite.Location = new System.Drawing.Point(12, 9);
            this.lblWrite.Name = "lblWrite";
            this.lblWrite.Size = new System.Drawing.Size(125, 29);
            this.lblWrite.TabIndex = 2;
            this.lblWrite.Text = "Eintragen";
            // 
            // lblShowScore
            // 
            this.lblShowScore.AutoSize = true;
            this.lblShowScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowScore.Location = new System.Drawing.Point(15, 38);
            this.lblShowScore.Name = "lblShowScore";
            this.lblShowScore.Size = new System.Drawing.Size(0, 25);
            this.lblShowScore.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 79);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "dein Name:";
            // 
            // txtYourName
            // 
            this.txtYourName.Location = new System.Drawing.Point(157, 76);
            this.txtYourName.Name = "txtYourName";
            this.txtYourName.Size = new System.Drawing.Size(100, 20);
            this.txtYourName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 123);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 32);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(140, 123);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(117, 32);
            this.btnAbort.TabIndex = 16;
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // frmEditScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 168);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtYourName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblShowScore);
            this.Controls.Add(this.lblWrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditScore";
            this.Text = "Resultat speichern";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditScore_FormClosing);
            this.Load += new System.EventHandler(this.frmEditScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWrite;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtYourName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbort;
        public System.Windows.Forms.Label lblShowScore;
    }
}