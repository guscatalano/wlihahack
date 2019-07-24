using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WlihaInputUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPicker : ContentPage
    {
        private ExtendedMap map;
        private Pin activePin;
        private Geocoder geocoder;
        private TaskCompletionSource<string> pickResult;

        public static async Task<string> ModalPickAddress(INavigation where, String hint)
        {
            var picker = new AddressPicker(hint);

            await where.PushModalAsync(picker, true);
            var result = await picker.pickResult.Task;
            await where.PopModalAsync();
            return result;
        }

        public AddressPicker(String hint)
        {
            InitializeComponent();

            map = new ExtendedMap(
                MapSpan.FromCenterAndRadius(
                    new Position(47.60357, -122.32945),
                    new Distance(3000)
                )
            )
            {
                MapType = MapType.Street,
                IsShowingUser = true
            };
            map.Tap += Map_Tap;
            layout.Children.Insert(1, map);

            activePin = new Pin();
            geocoder = new Geocoder();
            pickResult = new TaskCompletionSource<string>();

            if ((hint!=null) && (hint != ""))
            {
                CrossGeolocator.Current.GetPositionsForAddressAsync(hint).ContinueWith(
                    (result) => Device.BeginInvokeOnMainThread(
                            () =>
                            {
                                var location = result.Result.FirstOrDefault();
                                if (location != null)
                                {
                                    UpdatePosition(
                                        new Position(location.Latitude, location.Longitude),
                                        new Distance(Math.Max(location.Accuracy, 100))
                                        );
                                }
                            }
                        )
                    );

            }
            else
            {
                CrossGeolocator.Current.GetPositionAsync().ContinueWith(
                    (result) => Device.BeginInvokeOnMainThread(
                            () =>
                            {
                                if (result.Result != null)
                                {
                                    UpdatePosition(
                                        new Position(result.Result.Latitude, result.Result.Longitude),
                                        new Distance(Math.Max(result.Result.Accuracy, 100))
                                        );
                                }
                            }
                        )
                    );
            }
        }

        private void Map_Tap(object sender, TapEventArgs e)
        {
            UpdatePosition(e.Position, map.VisibleRegion.Radius);
        }

        private void UpdatePosition(Position position, Distance radius)
        {
            activePin.Position = position;
            activePin.Label = "Fetching address ...";
            activePin.Type = PinType.Place;

            if (!map.Pins.Contains(activePin))
            {
                map.Pins.Add(activePin);
            }
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position,radius));

            geocoder.GetAddressesForPositionAsync(position).ContinueWith(
                (result) => Device.BeginInvokeOnMainThread(
                        () => ResolveComplete(result.Result)
                    )
                );
        }

        private void ResolveComplete(IEnumerable<String> addresses)
        {
            alternativePicker.Items.Clear();
            foreach (var addr in addresses)
            {
                alternativePicker.Items.Add(addr);
            }

            if (addresses.Count() == 0)
            {
                alternativePicker.Items.Add("Failed to find address");
                accept.IsEnabled = false;
            }
            else
            {
                activePin.Label = addresses.First();
                accept.IsEnabled = true;
            }
            alternativePicker.SelectedIndex = 0;
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            pickResult.SetResult((string)alternativePicker.SelectedItem);
        }
    }
}