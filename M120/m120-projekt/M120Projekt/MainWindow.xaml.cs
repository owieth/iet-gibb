using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public static Bearbeitsungsansicht bearbeitsungsansicht;
        public static Zustände Zustand { get; set; }
        public static long ID;

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();

            zurückButton.Content = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/assets/backbutton.png")),
                VerticalAlignment = VerticalAlignment.Center
            };


            Data.Global.context = new Data.Context();

            contentContainer.Children.Clear();
            contentContainer.Children.Add(new LayoutApplikation());

        }

        public enum Zustände
        {
            List,
            Detail,
            Ändern,
            Neu,
        }

        private void zurückButtonClick(object sender, RoutedEventArgs e)
        {
            switch (Zustand)
            {
                case Zustände.Detail:
                    MainWindow.Instance.contentContainer.Children.Clear();
                    MainWindow.Instance.contentContainer.Children.Add(new LayoutApplikation());
                    break;

                case Zustände.Neu:
                    MainWindow.Instance.contentContainer.Children.Clear();
                    MainWindow.Instance.contentContainer.Children.Add(new LayoutApplikation());
                    break;

                case Zustände.Ändern:
                    Data.Auto auto = APIDemo.findAutoById(MainWindow.ID);
                    if (bearbeitsungsansicht.valuesChanged())
                    {
                        MessageBoxResult messageBox = MessageBox.Show("Wollen Sie die Änderungen nicht speichern?",
                        "Änderungen verwerfen?", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (messageBox == MessageBoxResult.Yes)
                        {
                            MainWindow.Instance.contentContainer.Children.Clear();
                            MainWindow.Instance.contentContainer.Children.Add(new Detailansicht(MainWindow.ID));
                        }
                    }
                    else
                    {
                        MainWindow.Instance.contentContainer.Children.Clear();
                        MainWindow.Instance.contentContainer.Children.Add(new Detailansicht(MainWindow.ID));
                    }
                    break;
            }
        }
    }
}