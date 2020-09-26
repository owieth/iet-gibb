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
    /// Interaktionslogik für NeuerstellenAnsicht.xaml
    /// </summary>
    public partial class NeuerstellenAnsicht : UserControl
    {
        bool bool1 = false;
        bool bool2 = false;
        bool bool3 = false;
        bool bool4 = false;
        bool bool5 = false;
        bool bool6 = false;
        bool bool7 = false;

        const string Beschreibung = "";
        const string Bezeichnung = @"^[\w]+$";
        const string Leistung = "^[0-9]{2,4}$";
        const string Farbe = @"^[\w]{2,8}$";
        const string Kilometerstand = @"^[\d]+$";
        const string Preis = @"^[0-9]+$";

        public NeuerstellenAnsicht()
        {
            InitializeComponent();
            MainWindow.Zustand = MainWindow.Zustände.Neu;

        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.contentContainer.Children.Clear();
            MainWindow.Instance.contentContainer.Children.Add(new LayoutApplikation());
        }

        private void createAutoButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Auto auto = new Data.Auto();
            auto.Beschreibung = textboxBeschreibung.Text;
            auto.AutoBezeichnung = textboxBezeichnung.Text;
            auto.Leistung = long.Parse(textboxLeistung.Text);
            auto.Farbe = textboxFarbe.Text;
            auto.Kilometerstand = long.Parse(textboxKilometerstand.Text);
            auto.Inverkehrssetzung = Convert.ToDateTime(datePickerInverkehrssetzung.Text);

            if ((bool) checkboxNeuwertig.IsChecked)
            {
                auto.Zustand = true;
            } else
            {
                auto.Zustand = false;
            }
            auto.Preis = long.Parse(textboxPreis.Text);
            Int64 autoID = auto.Erstellen();

            MainWindow.Instance.contentContainer.Children.Clear();
            MainWindow.Instance.contentContainer.Children.Add(new LayoutApplikation());
        }

        private void Detailansicht_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime? selectedDate = datePickerInverkehrssetzung.SelectedDate;

            if (selectedDate.HasValue)
            {
                validationInverkehr.Source = getCorrect();
                bool1 = true;
            }
            else
            {
                validationInverkehr.Source = getIncorrect();
                bool1 = false;
            }


            Dictionary<TextBox, string> liste = new Dictionary<TextBox, string>();
            liste.Add(textboxBeschreibung, Beschreibung);
            liste.Add(textboxBezeichnung, Bezeichnung);
            liste.Add(textboxLeistung, Leistung);
            liste.Add(textboxFarbe, Farbe);
            liste.Add(textboxKilometerstand, Kilometerstand);
            liste.Add(textboxPreis, Preis);


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
                            validationAutoBezeichnung.Source = getCorrect();
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
                    validationAutoBezeichnung.Source = getIncorrect();
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
    } 
}
