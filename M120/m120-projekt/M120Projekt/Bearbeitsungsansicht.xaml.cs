using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Bearbeitsungsansicht.xaml
    /// </summary>
    public partial class Bearbeitsungsansicht : UserControl
    {
        const string Beschreibung = "";
        const string Bezeichnung = @"^[\w]+$";
        const string Leistung = "^[0-9]{2,4}$";
        const string Farbe = @"^[\w]{2,8}$";
        const string Kilometerstand = @"^[\d]+$";
        const string Preis = @"^[0-9]+$";

        bool bool1 = false;
        bool bool2 = false;
        bool bool3 = false;
        bool bool4 = false;
        bool bool5 = false;
        bool bool6 = false;
        bool bool7 = false;

        public Bearbeitsungsansicht(long id)
        {
            MainWindow.ID = id;
            InitializeComponent();

            Data.Auto auto = APIDemo.findAutoById(MainWindow.ID);

            MainWindow.Zustand = MainWindow.Zustände.Ändern;

            imageCar.Content = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/assets/auto.png")),
                VerticalAlignment = VerticalAlignment.Center
            };


            textboxBeschreibung.Text = auto.Beschreibung;
            textBoxAutoBezeichnung.Text = auto.AutoBezeichnung;
            textBoxLeistung.Text = auto.Leistung.ToString();
            textBoxFarbe.Text = auto.Farbe;
            textBoxKilometerstand.Text = auto.Kilometerstand.ToString();
            datePickerInverkehrssetzung.Text = auto.Inverkehrssetzung.ToString();
            if (auto.Zustand == true)
            {
                checkboxNeuwertig.IsChecked = true;
            }
            else
            {
                checkboxNeuwertig.IsChecked = false;
            }
            textBoxPreis.Text = auto.Preis.ToString();

        }

        public List<TextBox> getBoxes()
        {
            List<TextBox> textboxList = new List<TextBox>();
            textboxList.Add(textboxBeschreibung);
            textboxList.Add(textBoxAutoBezeichnung);
            textboxList.Add(textBoxLeistung);
            textboxList.Add(textBoxFarbe);
            textboxList.Add(textBoxKilometerstand);
            textboxList.Add(textBoxPreis);

            return textboxList;
        }

        private void BearbeitsungsAnsicht_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime? selectedDate = datePickerInverkehrssetzung.SelectedDate;

            if (selectedDate.HasValue)
            {
                validationInverkehrssetzung.Source = getCorrect();
                bool1 = true;
            }
            else
            {
                validationInverkehrssetzung.Source = getIncorrect();
                bool1 = false;
            }


            Dictionary<TextBox, string> liste = new Dictionary<TextBox, string>();
            liste.Add(textboxBeschreibung, Beschreibung);
            liste.Add(textBoxAutoBezeichnung, Bezeichnung);
            liste.Add(textBoxLeistung, Leistung);
            liste.Add(textBoxFarbe, Farbe);
            liste.Add(textBoxKilometerstand, Kilometerstand);
            liste.Add(textBoxPreis, Preis);


            foreach (KeyValuePair<TextBox, string> kpv in liste)
            {
                Regex regex = new System.Text.RegularExpressions.Regex(kpv.Value);
                Match match = regex.Match(kpv.Key.Text);

                if (match.Success)
                {
                    switch (kpv.Value)
                    {
                        case Beschreibung:
                            textboxBeschreibung.BorderBrush = Brushes.Green;
                            bool2 = true;
                            break;

                        case Bezeichnung:
                            validationBezeichnung.Source = getCorrect();
                            bool3 = true;
                            break;

                        case Leistung:
                            validationLeistung.Source = getCorrect();
                            bool4 = true;
                            break;

                        case Farbe:
                            validationFarbe.Source = getCorrect();
                            bool5 = true;
                            break;

                        case Kilometerstand:
                            validationKilometerstand.Source = getCorrect();
                            bool6 = true;
                            break;

                        case Preis:
                            validationPreis.Source = getCorrect();
                            bool7 = true;
                            break;
                    }
                }
                else if (kpv.Value == Beschreibung)
                {
                    textboxBeschreibung.BorderBrush = Brushes.Red;
                    bool2 = false;
                }
                else if (kpv.Value == Bezeichnung)
                {
                    validationBezeichnung.Source = getIncorrect();
                    bool3 = false;
                }
                else if (kpv.Value == Leistung)
                {
                    validationLeistung.Source = getIncorrect();
                    bool4 = false;
                }
                else if (kpv.Value == Farbe)
                {
                    validationFarbe.Source = getIncorrect();
                    bool5 = false;
                }
                else if (kpv.Value == Kilometerstand)
                {
                    validationKilometerstand.Source = getIncorrect();
                    bool6 = false;
                }
                else if (kpv.Value == Preis)
                {
                    validationPreis.Source = getIncorrect();
                    bool7 = false;
                }
            }

            if (bool1 == true && bool2 == true && bool3 == true && bool4 == true && bool5 == true && bool6 == true && bool7 == true)
            {
                buttonSpeichern.IsEnabled = true;
            }
            else
            {
                buttonSpeichern.IsEnabled = false;
            }
        }

        public BitmapImage getCorrect()
        {
            return new BitmapImage(new Uri("pack://application:,,,/assets/validation_correct.png"));
        }

        public BitmapImage getIncorrect()
        {
            return new BitmapImage(new Uri("pack://application:,,,/assets/validation_incorrect.png"));
        }

        private void ButtonLöschen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Wollen Sie dieses Auto wirklich löschen?",
            "Löschvorgang", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBox == MessageBoxResult.Yes)
            {
                Data.Auto auto = APIDemo.findAutoById(MainWindow.ID);
                auto.Loeschen();

                MainWindow.Instance.contentContainer.Children.Clear();
                MainWindow.Instance.contentContainer.Children.Add(new LayoutApplikation());
            }
        }

        private void ButtonSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Data.Auto auto = APIDemo.findAutoById(MainWindow.ID);
            auto.Beschreibung = textboxBeschreibung.Text;
            auto.AutoBezeichnung = textBoxAutoBezeichnung.Text;
            auto.Leistung = long.Parse(textBoxLeistung.Text);
            auto.Farbe = textBoxFarbe.Text;
            auto.Kilometerstand = long.Parse(textBoxKilometerstand.Text);
            auto.Inverkehrssetzung = Convert.ToDateTime(datePickerInverkehrssetzung.Text);

            if ((bool)checkboxNeuwertig.IsChecked)
            {
                auto.Zustand = true;
            }
            else
            {
                auto.Zustand = false;
            }
            auto.Preis = long.Parse(textBoxPreis.Text);
            auto.Aktualisieren();

            MainWindow.Instance.contentContainer.Children.Clear();
            MainWindow.Instance.contentContainer.Children.Add(new Detailansicht(MainWindow.ID));
        }

        public bool valuesChanged()
        {
            Data.Auto auto = APIDemo.findAutoById(MainWindow.ID);

            bool changed = false;

            if (auto.Beschreibung != textboxBeschreibung.Text)
            {
                changed = true;
            }
            if (auto.AutoBezeichnung != textBoxAutoBezeichnung.Text)
            {
                changed = true;
            }
            if (auto.Leistung.ToString() != textBoxLeistung.Text)
            {
                changed = true;
            }
            if (auto.Farbe != textBoxFarbe.Text)
            {
                changed = true;
            }

            if (auto.Kilometerstand.ToString() != textBoxKilometerstand.Text)
            {
                changed = true;
            }

            if (auto.Inverkehrssetzung != datePickerInverkehrssetzung.SelectedDate)
            {
                changed = true;
            }

            if (auto.Zustand != checkboxNeuwertig.IsChecked)
            {
                changed = true;
            }

            if (auto.Preis.ToString() != textBoxPreis.Text)
            {
                changed = true;
            }
            return changed;

        }
    }
}