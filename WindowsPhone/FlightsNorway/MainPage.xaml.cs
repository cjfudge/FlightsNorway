﻿using System;
using System.Windows;
using FlightsNorway.Lib.DataServices;
using FlightsNorway.Lib.Model;
using Microsoft.Phone.Controls;

namespace FlightsNorway
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var flightsService = new FlightsService();
            flightsService.GetFlightsFrom(flights =>
            {
                Deployment.Current.Dispatcher.BeginInvoke(
                    () => _airports.ItemsSource = flights.Value);
            }, new Airport { Code = "OSL" });

        }
    }
}