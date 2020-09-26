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
    public partial class frmScoreList : Form
    {
        public string _path; //Pfad für Highscore-Datei.
        private frmField field;
        public frmScoreList(frmField field)
        {
            InitializeComponent();
            this.field = field as frmField;
            _path = field._pathOfHighscore;
        }
        public void RefreshScore()
        {
            if (_path == "" || _path == null || !File.Exists(_path))
            {
                txtScoreList.Text = "Rangliste nicht verfügbar.";
            }
            else
            {
                txtScoreList.Text = File.ReadAllText(_path);
            }
        }

        private void btnScoreList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmScoreList_Load(object sender, EventArgs e)
        {
            RefreshScore();
        }
    }
}
