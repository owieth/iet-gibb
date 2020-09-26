using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CollectJoe___Projekt_M404
{
    public partial class frmField : Form
    {
        private frmOptions settings;
        public frmEditScore editScore;
        public int _countRandomButtons; //Zählt Anzahl von Buttons in Feld.
        public int _amountBoxesHorinzontal; //Anzahl Boxen in Horinzontale.
        public int _amountBoxesVertical; //Anzahl Boxen in Vertikale.
        private int _heightBox; //Höhe von Box
        private int _widthBox; //Breite von Box.
        public string _pathOfHighscore; //String für Pfad der Highscoredatei.
        public Color _backColorButton; //Farbe der Box.
        public List<Button> _buttonList = new List<Button>(); //Liste mit allen Buttons auf Spielfeld.
        public Dictionary<Color, int> _buttonDictionary = new Dictionary<Color, int>(); //Dictonary mit Farben und Wert der Randombuttons auf Feld.
        public int[] _distance = new int[] { 10, 10 }; //Array für Abstand zwischen Buttons und Panelrand.
        public Random _randomColors = new Random(); //Random für eine random Farbe von den drei Boxen.
        public Button[,] _buttons; //Butonsarray für Spielfeld.
        public int _time; //Spielzeit

        public frmField()
        {
            string _path = Path.Combine(Environment.CurrentDirectory, "Highscore.txt"); 
            _pathOfHighscore = _path;
            editScore = new frmEditScore(this);
            InitializeComponent();
            btnStart.Enabled = false;
        }

        public void StopGame()
        {
            tmrGame.Stop();
            btnOptions.Enabled = true;
            btnScoreList.Enabled = true;
            btnStart.Enabled = true;

            if (Convert.ToInt32(txtPointCounter.Text) <= 0)
            {
                MessageBox.Show("GAME OVER!", "GAME OVER!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
               editScore.ShowDialog();
               editScore.lblShowScore.Text = txtPointCounter.Text;
            }
        }

        public void SetOptions() //In der Methode werden die Einstellungen für das Spiel gesetzt und das Feld gebaut.
        {
            settings.GetHorizontal();
            settings.GetVertical();
            settings.GetValue("_textBoxName");
            BuildButtonField();
        }

        private void BuildButtonField() //Buttonfield wird gebaut.
        {
            _buttons = new Button[_amountBoxesVertical, _amountBoxesHorinzontal];

            _heightBox = ((pnlGame.Height - 2 * (_distance[1])) / _amountBoxesVertical);
            _widthBox = ((pnlGame.Width - 2 * (_distance[0])) / _amountBoxesHorinzontal);

            for (int i = 0; i < _amountBoxesVertical; i++)
            {
                for (int j = 0; j < _amountBoxesHorinzontal; j++)
                {
                    Button tempButton = new Button();
                    tempButton.Name = "tempButton";
                    tempButton.BackColor = settings.btnBoxColors.BackColor;
                    tempButton.Height = _heightBox;
                    tempButton.Width = _widthBox;
                    tempButton.Location = new Point(j * tempButton.Width + _distance[0], i * tempButton.Height + _distance[1]);
                    pnlGame.Controls.Add(tempButton);
                    _buttonList.Add(tempButton);
                    tempButton.Click += new EventHandler(btnBox_Click);
                    _countRandomButtons++;
                    _buttons[i, j] = tempButton;
                }
            }
            pnlGame.BackColor = settings.btnFieldColor.BackColor;
        }

        private void btnScoreList_Click(object sender, EventArgs e)
        {
            frmScoreList ScoreList = new frmScoreList(this);
            ScoreList.Show();
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            try
            {
                settings.Show();
            }
            catch (Exception) {
                settings = new frmOptions(this);
                settings.Show();
            }
            _buttonDictionary.Clear();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtPointCounter.Text = "0";
            btnOptions.Enabled = false;
            btnScoreList.Enabled = false;
            btnStart.Enabled = false;
            _time = Convert.ToInt32(settings.txtTime.Text);
            tmrGame.Interval = Convert.ToInt32(settings.txtSpeed.Text);
            tmrGame.Start(); 
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            _time--;
            txtTime.Text = Convert.ToString(_time);
            if (_time <= 0)
            {
                _time++;
                StopGame();
            }
            else {
                settings.RandomColor();
                settings.RandomButton();
            } 
        }
        private void btnBox_Click(object sender, EventArgs e)
        {
            if (tmrGame.Enabled)
            {
                if ((sender as Button).BackColor != settings.btnBoxColors.BackColor) {
                    txtPointCounter.Text = Convert.ToString(Convert.ToInt32(txtPointCounter.Text) + _buttonDictionary[(sender as Button).BackColor]);
                }

                if (Convert.ToInt32(txtPointCounter.Text) < 0)
                {
                    StopGame();
                }
            }
        }
        private void btnHideOptions_Click(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
