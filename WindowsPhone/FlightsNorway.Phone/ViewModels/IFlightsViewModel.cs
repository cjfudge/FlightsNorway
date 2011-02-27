﻿using System.Collections.ObjectModel;
using FlightsNorway.Model;

namespace FlightsNorway.ViewModels
{
    public interface IFlightsViewModel
    {
        ObservableCollection<Flight> Arrivals { get; }
        ObservableCollection<Flight> Departures { get; }
        Airport SelectedAirport { get; set; }
    }
}