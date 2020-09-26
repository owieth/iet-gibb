namespace CollectJoe___Projekt_M404
{
    partial class frmField
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmField));
            this.pnlGame = new System.Windows.Forms.Panel();
            this.txtPointCounter = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnScoreList = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlGame.Location = new System.Drawing.Point(13, 13);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(695, 316);
            this.pnlGame.TabIndex = 0;
            // 
            // txtPointCounter
            // 
            this.txtPointCounter.Enabled = false;
            this.txtPointCounter.Location = new System.Drawing.Point(254, 342);
            this.txtPointCounter.Name = "txtPointCounter";
            this.txtPointCounter.Size = new System.Drawing.Size(75, 20);
            this.txtPointCounter.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 335);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(117, 32);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Spiel starten";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(138, 341);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(115, 20);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Punktestand:";
            // 
            // btnScoreList
            // 
            this.btnScoreList.Location = new System.Drawing.Point(468, 335);
            this.btnScoreList.Name = "btnScoreList";
            this.btnScoreList.Size = new System.Drawing.Size(117, 32);
            this.btnScoreList.TabIndex = 3;
            this.btnScoreList.Text = "Rangliste anzeigen";
            this.btnScoreList.UseVisualStyleBackColor = true;
            this.btnScoreList.Click += new System.EventHandler(this.btnScoreList_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(591, 335);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(117, 32);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.Text = "Einstellungen";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 1000;
            this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(387, 341);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(75, 20);
            this.txtTime.TabIndex = 5;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(336, 341);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(45, 20);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Zeit:";
            // 
            // frmField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 373);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnScoreList);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPointCounter);
            this.Controls.Add(this.pnlGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmField";
            this.Text = "CollectJoe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnScoreList;
        private System.Windows.Forms.Button btnOptions;
        public System.Windows.Forms.Panel pnlGame;
        public System.Windows.Forms.TextBox txtPointCounter;
        public System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Timer tmrGame;
    }
}

