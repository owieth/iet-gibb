namespace CollectJoe___Projekt_M404
{
    partial class frmScoreList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScoreList));
            this.lblScoreList = new System.Windows.Forms.Label();
            this.txtScoreList = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScoreList
            // 
            this.lblScoreList.AutoSize = true;
            this.lblScoreList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreList.Location = new System.Drawing.Point(12, 9);
            this.lblScoreList.Name = "lblScoreList";
            this.lblScoreList.Size = new System.Drawing.Size(123, 29);
            this.lblScoreList.TabIndex = 1;
            this.lblScoreList.Text = "Rangliste";
            // 
            // txtScoreList
            // 
            this.txtScoreList.Location = new System.Drawing.Point(13, 42);
            this.txtScoreList.Multiline = true;
            this.txtScoreList.Name = "txtScoreList";
            this.txtScoreList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScoreList.Size = new System.Drawing.Size(259, 178);
            this.txtScoreList.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 226);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 32);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmScoreList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 269);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtScoreList);
            this.Controls.Add(this.lblScoreList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScoreList";
            this.Text = "Rangliste";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnScoreList_FormClosing);
            this.Load += new System.EventHandler(this.frmScoreList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScoreList;
        private System.Windows.Forms.TextBox txtScoreList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnClose;
    }
}