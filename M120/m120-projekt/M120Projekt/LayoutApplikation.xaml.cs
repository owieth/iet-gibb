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
    /// Interaktionslogik für LayoutApplikation.xaml
    /// </summary>
    public partial class LayoutApplikation : UserControl
    {
        public LayoutApplikation()
        {
            InitializeComponent();
            MainWindow.Zustand = MainWindow.Zustände.List;

            fillListe();
        }


        private void showCarDetailsClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.contentContainer.Children.Clear();
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Tag);
            long autoID = (long)id;
            MainWindow.Instance.contentContainer.Children.Add(new Detailansicht(autoID));
        }

        private void newCarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.contentContainer.Children.Clear();
            MainWindow.Instance.contentContainer.Children.Add(new NeuerstellenAnsicht());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void fillListe()
        {
            List<Data.Auto> autos = APIDemo.getAllAutos();

            foreach (Data.Auto auto in autos)
            {
                Button button = new Button
                {
                    Width = 200,
                    Height = 100,
                    Margin = new Thickness(0, 10, 20, 10),
                    Tag = auto.AutoID,
                    HorizontalAlignment = HorizontalAlignment.Center,

                Content = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/assets/auto.png")),
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };

                button.Click += new RoutedEventHandler(showCarDetailsClick);

                listContainer.Children.Add(button);
            }
        }
    }
}
