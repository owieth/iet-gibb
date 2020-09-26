using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectJoe___Projekt_M404
{
    public partial class frmOptions : Form
    {
        private int _value1; //Variable für Wert von Box1.
        private int _value2; //Variable für Wert von Box2.
        private int _value3; //Variable für Wert von Box3.
        public frmField field = null;
        public int _randomSpeed;
        Random _showRandomButtonOnField = new Random();
        Random _backcolor = new Random();

        public frmOptions(frmField field)
        {
            this.field = field as frmField;
            InitializeComponent();
        }

        public void GetHorizontal() //Methode für Anzahl von Buttons, die erstellt werden sollen horizontal.
        {
            if (!(txtBoxesHorizontal.Text == ""))
            {
                field._amountBoxesHorinzontal = Convert.ToInt32(txtBoxesHorizontal.Text);
            }

            if (field._amountBoxesHorinzontal > 20 || field._amountBoxesHorinzontal == 0)
            {
                field._amountBoxesHorinzontal = 20;
                txtBoxesHorizontal.Text = Convert.ToString(field._amountBoxesHorinzontal);
                MessageBox.Show("Höchstwert = 20");
            }

            else if (field._amountBoxesHorinzontal < 1)
            {
                field._amountBoxesHorinzontal = 10;
                txtBoxesHorizontal.Text = Convert.ToString(field._amountBoxesHorinzontal);
            }
        }

        public void GetVertical()//Methode für Anzahl von Buttons, die erstellt werden sollen vertikal.
        {
            if (!(txtBoxesVertical.Text == ""))
            {
                field._amountBoxesVertical = Convert.ToInt32(txtBoxesVertical.Text);
            }


            if (field._amountBoxesVertical > 10 || field._amountBoxesVertical == 0)
            {
                field._amountBoxesVertical = 10;
                txtBoxesVertical.Text = Convert.ToString(field._amountBoxesVertical);
                MessageBox.Show("Höchstwert = 10");
            }

            else if (field._amountBoxesVertical < 1)
            {
                field._amountBoxesVertical = 10;
                txtBoxesVertical.Text = Convert.ToString(field._amountBoxesVertical);
            }
        }

        public int GetValue(String _textBoxName) //Methode für die Werte der drei Boxtypen.
        {
            Control[] controls = this.Controls.Find(_textBoxName, true);
            if (!(controls.Length < 1))
            {
                TextBox activeTextBox = (TextBox)controls[0];
            }
            else
            {
                return 1;
            }
            return 0;
        }

        public Color GetColor(String _buttonName) //Hintergrundfarbe von allen Buttons.
        {
            Control[] controls = this.Controls.Find(_buttonName, true);

            Button tempbutton = (Button)controls[0];
            return tempbutton.BackColor;
        }

        public void RandomColor()
        {
            int _randomColor = field._randomColors.Next(1, 4);

            switch (_randomColor)
            {
                case 1:
                    field._backColorButton = btnBoxColor1.BackColor;
                    break;

                case 2:
                    field._backColorButton = btnBoxColor2.BackColor;
                    break;

                case 3:
                    field._backColorButton = btnBoxColor3.BackColor;
                    break;

                default:
                    break;
            }
        }

        public void RandomButton()
        {
            Control[] allButtons = field.pnlGame.Controls.Find("tempButton", false);
            int randomIndex = _backcolor.Next(0, allButtons.Length);
            foreach (Button b in allButtons) {
                b.BackColor = btnBoxColors.BackColor;
            }

            allButtons[randomIndex].BackColor = field._backColorButton;

        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            field.btnStart.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            field.SetOptions();
            field.btnStart.Enabled = true;

            if (!(txtFirstBox.Text == "" && txtSecondBox.Text == "" && txtThirdBox.Text == ""))
            {
                _value1 = Convert.ToInt32(txtFirstBox.Text);
                _value2 = Convert.ToInt32(txtSecondBox.Text);
                _value3 = Convert.ToInt32(txtThirdBox.Text);
            }
            else
            {
                _value1 = 1;
                txtFirstBox.Text = Convert.ToString(_value1);
                _value2 = 2;
                txtSecondBox.Text = Convert.ToString(_value2);
                _value3 = 3;
                txtThirdBox.Text = Convert.ToString(_value3);
            }


            if (!(btnBoxColor1.BackColor == btnBoxColor2.BackColor || btnBoxColor2.BackColor == btnBoxColor3.BackColor || btnBoxColor1.BackColor == btnBoxColor3.BackColor))
            {
                field._buttonDictionary.Add(btnBoxColor1.BackColor, _value1);
                field._buttonDictionary.Add(btnBoxColor2.BackColor, _value2);
                field._buttonDictionary.Add(btnBoxColor3.BackColor, _value3);
            }
            else
            {
                MessageBox.Show("Boxfarbe darf nur einmal verwendet werden!");
                btnBoxColor1.BackColor = Color.Blue;
                btnBoxColor2.BackColor = Color.Red;
                btnBoxColor3.BackColor = Color.Green;
            }
            this.Hide();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).BackColor = colorDialog1.Color;
            }
        }
    }
}
