﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Atmero = (int)Vastagsag.vekony;
        private Brush Ecsetszin = Brushes.Black;
        private bool festes = false;
        private enum Vastagsag
        {
            vekony=5,
            kozepes=10,
            vastag=30

        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void KilepClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan ki akar lépni?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ecset(Brush szin,Point position)
        {
            Ellipse newellipse = new Ellipse();
            newellipse.Fill = szin;
            newellipse.Width = Atmero;
            newellipse.Height = Atmero;
            Canvas.SetTop(newellipse, position.Y);
            Canvas.SetLeft(newellipse, position.X);
            Vaszon.Children.Add(newellipse);
        }

        private void PirosClick(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                Ecsetszin = Brushes.Red;
            }
        }

        private void ZoldClick(object sender, RoutedEventArgs e)
        {
            Ecsetszin = Brushes.Green;
        }

        private void KekClick(object sender, RoutedEventArgs e)
        {
            Ecsetszin = Brushes.Blue;
        }

        private void VekonyClick(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                Atmero = (int)Vastagsag.vekony;
            }
        }

        private void KozepesClick(object sender, RoutedEventArgs e)
        {
            Atmero = (int)Vastagsag.kozepes;
        }

        private void VastagClick(object sender, RoutedEventArgs e)
        {
            Atmero = (int)Vastagsag.vastag;
        }

        private void Vaszon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            festes = true;
        }

        private void Vaszon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            festes = false;
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (festes)
            {
                Point mouseposition = e.GetPosition(Vaszon);
                ecset(Ecsetszin, mouseposition);
            }

        }

        private void FeherClick(object sender, RoutedEventArgs e)
        {
            Vaszon.Background= new SolidColorBrush(Colors.White);
        }

        private void FeketeClick(object sender, RoutedEventArgs e)
        {
            Vaszon.Background = new SolidColorBrush(Colors.Black);
        }

        private void UjClick(object sender, RoutedEventArgs e)
        {
            Vaszon.Children.Clear();
        }
    }
}
