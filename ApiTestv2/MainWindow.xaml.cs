﻿using DemoLibraryv2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ApiTestv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;
        public ObservableCollection<FutbolModel> futbolTeams { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            

            NextButton.IsEnabled = true;
            PreviousButton.IsEnabled = false;
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }

            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            ComicImage.Source = new BitmapImage(uriSource);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //Si estoy en el ultimo, no quiero avanzar mas o si regresar al 1ro

            if (currentNumber <= maxNumber)
            {
                maxNumber++;
                currentNumber += 1;
                PreviousButton.IsEnabled = true;
            }
            else if (currentNumber > maxNumber)
            {
                currentNumber = 1;
                NextButton.IsEnabled = false;
            }

            await LoadImage(currentNumber);
        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                NextButton.IsEnabled = true;
            }
            else if (currentNumber == 1)
            {
                NextButton.IsEnabled = true;
                PreviousButton.IsEnabled = false;
            }

            await LoadImage(currentNumber);
        }

        private async void SunInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var sunInfo = await SunProcessor.LoadSunInformation();
            string messageBoxText = $"Sunrise Time: { sunInfo.Sunrise.ToLocalTime().ToShortTimeString() }\n" +
                $"Sunset Time: { sunInfo.Sunset.ToLocalTime().ToShortTimeString() }";
            string caption = "Sun Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        private async void LoadTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            //futbolTeams = await FutbolProcessor.LoadFutbolInformation();

            futbolTeams = new ObservableCollection<FutbolModel>();

            futbolTeams.Add(new FutbolModel() { Data = "Team 1" });
            futbolTeams.Add(new FutbolModel() { Data = "Team 2" });
            futbolTeams.Add(new FutbolModel() { Data = "Team 3" });

            //'this' apunta a futbolTeams
            FutbolDataList.DataContext = this;
        }
    }
}
