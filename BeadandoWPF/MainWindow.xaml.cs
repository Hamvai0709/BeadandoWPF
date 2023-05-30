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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeadandoWPF
{
    // Hamvai Soma - M72A20
// Festő/rajzoló felület létrehozása WPF segítségével
    public partial class MainWindow : Window
    {
        private int Atmero = (int)Vastagsag.vekony; // átmérő létrehozása, alapértelmezés szerint vékony az ecset vastagsága (5p)
        private Brush Ecsetszin = Brushes.Black; // ecset szín, alapértelmezés szerint fekete
        private bool festes = false;    // festés változó true/false -> éppen lenyomva van e az egér azaz festünk/rajzolunk e vagy sem
        private enum Vastagsag //vastagsagok megadasa
        {
            vekony=5,
            kozepes=10,
            vastag=30

        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void KilepClick(object sender, RoutedEventArgs e) // kilépés messagebox-al megerősítéssel
        {
            MessageBoxResult result = MessageBox.Show("Biztosan ki akar lépni?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ecset(Brush szin,Point position) // ecset létrehozása ellipse-l, kitöltés, méret, pozíció beállítása
        {
            Ellipse newellipse = new Ellipse();
            newellipse.Fill = szin;
            newellipse.Width = Atmero;
            newellipse.Height = Atmero;
            Canvas.SetTop(newellipse, position.Y);
            Canvas.SetLeft(newellipse, position.X);
            Vaszon.Children.Add(newellipse);
        }

        private void PirosClick(object sender, RoutedEventArgs e) // ecset színének változtatása pirosra
        {
                Ecsetszin = Brushes.Red;
        }

        private void ZoldClick(object sender, RoutedEventArgs e) // ecset színének változtatása zöldre
        {
            Ecsetszin = Brushes.Green;
        }

        private void KekClick(object sender, RoutedEventArgs e) // ecset színének változtatása kékre
        {
            Ecsetszin = Brushes.Blue;
        }

        private void VekonyClick(object sender, RoutedEventArgs e) // ecset átmérőjének változtatása vékonyra
        {

                Atmero = (int)Vastagsag.vekony;
        }

        private void KozepesClick(object sender, RoutedEventArgs e) // ecset átmérőjének változtatása közepesre
        {
            Atmero = (int)Vastagsag.kozepes;
        }

        private void VastagClick(object sender, RoutedEventArgs e) // ecset átmérőjének változtatása vastagra
        {
            Atmero = (int)Vastagsag.vastag;
        }

        private void Vaszon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // az egér lenyomásakor festünk/rajzolunk
        {
            festes = true;
        }

        private void Vaszon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) // a bal click felengedése után abbahagyjuk a rajzolást/festést
        {
            festes = false;
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e) // egér mozgatása
        {
            if (festes)
            {
                Point mouseposition = e.GetPosition(Vaszon);
                ecset(Ecsetszin, mouseposition);
            }

        }

        private void FeherClick(object sender, RoutedEventArgs e) // háttérszín fehérre
        {
            Vaszon.Background= new SolidColorBrush(Colors.White);
        }

        private void FeketeClick(object sender, RoutedEventArgs e) // háttérszín feketére
        {
            Vaszon.Background = new SolidColorBrush(Colors.Black);
        }

        private void UjClick(object sender, RoutedEventArgs e) // vászon törlése/ új létrehozása megerősítéssel
        {
            MessageBoxResult result = MessageBox.Show("Új létrehozása/jelenlegi törlése?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Vaszon.Children.Clear();
            }

        }
    }
}
