using System;
using System.ComponentModel;
using System.Diagnostics;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using WorkSphere.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;

namespace WorkSphere.Views
{
    public partial class MainPage : ContentPage
    {
        private Map _map;

        public MainPage()
        {
            InitializeComponent();
            Load();
        }


        public async void Load()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    _map = new Map()
                    {
                        IsShowingUser = false,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        MapType = MapType.Street

                    };
                    
                    MapContainer.Children.Add(_map);

                    MainPageViewModel viewModel = this.BindingContext as MainPageViewModel;
                    if (viewModel != null)
                    {
                        viewModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
                        {
                            if (args.PropertyName.Equals("GpsPosition", StringComparison.CurrentCultureIgnoreCase))
                            {

                            }
                        };

                        IGeolocator geoLocator = CrossGeolocator.Current;
                        geoLocator.AllowsBackgroundUpdates = true;
                        geoLocator.DesiredAccuracy = 50;

                        if (!geoLocator.IsListening)
                        {
                            var listening = await geoLocator.StartListeningAsync(1000, 5);

                            if ((listening && geoLocator.IsListening) &&
                                (geoLocator.IsGeolocationAvailable && geoLocator.IsGeolocationEnabled))
                            {
                                geoLocator.PositionChanged += delegate (object sender, PositionEventArgs args)
                                {
                                    var position = new Position(args.Position.Latitude, args.Position.Longitude);
                                    SetMapsPosition(position);
                                };
                            }
                        }
                        else
                        {
                            Plugin.Geolocator.Abstractions.Position p = await geoLocator.GetPositionAsync(1000);
                            var position = new Position(p.Latitude, p.Longitude);
                            SetMapsPosition(position);
                        }

                    }
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
            }

        }


        private void SetMapsPosition(Position position)
        {
            _map.Pins.Clear();

            var zoom = Distance.FromMiles(0.1);

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "YOU",
                Address = String.Empty
            };
            _map.Pins.Add(pin);
            _map.MoveToRegion(MapSpan.FromCenterAndRadius(position, zoom));
        }

    }
}
