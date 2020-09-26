using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CollectJoe___Projekt_M404
{
    public partial class frmEditScore : Form
    {
        private string _path; //Pfad für Highscore-Datei.
        public frmField field;
        public frmEditScore(frmField field)
        {
            InitializeComponent();
            this.field = field as frmField;
            _path = field._pathOfHighscore;
        }
        public void SetScore()
        {
            lblShowScore.Text = Convert.ToString(field.txtPointCounter.Text);
        }

        public void ReSetNameAndScore()
        {
            txtYourName.Text = "";
            lblShowScore.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtYourName.Text == "")
            {
                MessageBox.Show("Bitte geben Sie ihren Namen ein.", "Keinen Namen eingegben", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                File.WriteAllText(_path, txtYourName.Text + ";" + lblShowScore.Text + Environment.NewLine + File.ReadAllText(_path));
                this.Hide();
            }

            field.pnlGame.Controls.Clear();
            field.pnlGame.BackColor = Color.FromArgb(0, 192, 0);
            field.txtPointCounter.Text = "0";
            field.btnStart.Enabled = false;
            field._time = 40;
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
            field.pnlGame.BackColor = Color.FromArgb(0, 192, 0);
            field.pnlGame.Controls.Clear();
            field.txtPointCounter.Text = "0";
            field.btnStart.Enabled = false;
            field._time = 40;
        }

        private void frmEditScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void frmEditScore_Load(object sender, EventArgs e)
        {
            SetScore();
        }
    }
}
