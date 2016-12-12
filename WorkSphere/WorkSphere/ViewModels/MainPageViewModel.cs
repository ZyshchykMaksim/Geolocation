using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Plugin.Geolocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Plugin.Geolocator.Abstractions;
using GPSPosition = WorkSphere.Models.Position;

namespace WorkSphere.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService = null;
        private GPSPosition _gpsPosition = null;

        public GPSPosition GpsPosition
        {
            get { return _gpsPosition; }
            set { SetProperty(ref _gpsPosition, value); }
        }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Main Page";
            GpsPosition = new GPSPosition(0, 0);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
