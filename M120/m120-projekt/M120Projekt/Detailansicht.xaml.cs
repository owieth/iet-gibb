using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Detailansicht.xaml
    /// </summary>
    public partial class Detailansicht : UserControl
    {
        public long id;

        public Detailansicht()
        {
            InitializeComponent();

            Data.Auto auto = APIDemo.findAutoById(1);
            autoBezeichnungLabel.Content = auto.AutoBezeichnung;
            beschreibungTextBlock.Text = auto.Beschreibung;
            leistungLabel.Content = auto.Leistung;
            farbeLabel.Content = auto.Farbe;
            kilometerstandLabel.Content = auto.Kilometerstand.ToString();
            inverkehrssetzunglabel.Content = auto.Inverkehrssetzung.ToString();
            if (auto.Zustand == true)
            {
                checkboxNeuwertig.IsChecked = true;
            }
            else
            {
                checkboxNeuwertig.IsChecked = false;
            }
            preisLabel.Content = auto.Preis;
        }

        public Detailansicht(Int64 id)
        {
            this.id = id;
            InitializeComponent();
            MainWindow.Zustand = MainWindow.Zustände.Detail;

            Data.Auto auto = new Data.Auto(); 
            auto = APIDemo.findAutoById(this.id);
            autoBezeichnungLabel.Content = auto.AutoBezeichnung;
            beschreibungTextBlock.Text = auto.Beschreibung;
            leistungLabel.Content = auto.Leistung;
            farbeLabel.Content = auto.Farbe;
            kilometerstandLabel.Content = auto.Kilometerstand.ToString();
            inverkehrssetzunglabel.Content = auto.Inverkehrssetzung.ToString();

            if (auto.Zustand == true)
            {
                checkboxNeuwertig.IsChecked = true;
            }
            else
            {
                checkboxNeuwertig.IsChecked = false;
            }
            preisLabel.Content = auto.Preis;
        }

        private void bearbeitenButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.contentContainer.Children.Clear();
            MainWindow.Instance.contentContainer.Children.Add(new Bearbeitsungsansicht(id));
            MainWindow.bearbeitsungsansicht = (Bearbeitsungsansicht)MainWindow.Instance.contentContainer.Children[0];
        }
    }
}
