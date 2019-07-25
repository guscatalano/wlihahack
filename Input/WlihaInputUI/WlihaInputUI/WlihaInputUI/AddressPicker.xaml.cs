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
    public class Address
    {
        public string streetAndNumber;
        public string city;
        public string zipcode;

        public override string ToString()
        {
            string result = streetAndNumber!=null ? streetAndNumber.Trim() : "";
            if (!String.IsNullOrWhiteSpace(city))
            {
                if (!String.IsNullOrWhiteSpace(result)) result += ", ";
                result += city;
            }
            if (!String.IsNullOrWhiteSpace(zipcode))
            {
                if (!String.IsNullOrWhiteSpace(zipcode)) result += ", ";
                result += zipcode;
            }
            return result;
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPicker : ContentPage
    {
        private ExtendedMap map;
        private Pin activePin;
        private Geocoder geocoder;
        private TaskCompletionSource<Address> pickResult;
        private List<Address> currentCandidates;

        public static async Task<Address> ModalPickAddress(INavigation where, Address hint)
        {
            var picker = new AddressPicker(hint);

            await where.PushModalAsync(picker, true);
            var result = await picker.pickResult.Task;
            await where.PopModalAsync();
            return result;
        }

        public AddressPicker(Address hint)
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
            layout.Children.Insert(0, map);

            activePin = new Pin();
            geocoder = new Geocoder();
            pickResult = new TaskCompletionSource<Address>();

            if ((hint!=null) && (hint.ToString() != ""))
            {
                CrossGeolocator.Current.GetPositionsForAddressAsync(hint.ToString()).ContinueWith(
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
            UpdatePosition(e.Position, map.VisibleRegion != null ? map.VisibleRegion.Radius : new Distance(300));
        }

        private void UpdatePosition(Xamarin.Forms.Maps.Position position, Distance radius)
        {
            activePin.Position = position;
            activePin.Label = "Fetching address ...";
            activePin.Type = PinType.Place;

            if (!map.Pins.Contains(activePin))
            {
                map.Pins.Add(activePin);
            }
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position,radius));

            var geoPos = new Plugin.Geolocator.Abstractions.Position(position.Latitude, position.Longitude);

            CrossGeolocator.Current.GetAddressesForPositionAsync(geoPos).ContinueWith(
                (result) => Device.BeginInvokeOnMainThread(
                        () => ResolveComplete(result.Result)
                    )
                );
        }

        private void ResolveComplete(IEnumerable<Plugin.Geolocator.Abstractions.Address> addresses)
        {
            currentCandidates = new List<Address>();
            alternativePicker.Items.Clear();
            foreach (var addr in addresses)
            {
                Address a = new Address();
                a.streetAndNumber = ((addr.SubThoroughfare ?? "") + " " + (addr.Thoroughfare ?? "")).Trim();
                a.city = addr.Locality != null ? addr.Locality.Trim() : "";
                a.zipcode = addr.PostalCode != null ? addr.PostalCode.Trim() : "";

                if ((a.ToString() != "") && (!currentCandidates.Contains(a)))
                {
                    currentCandidates.Add(a);
                    alternativePicker.Items.Add(a.ToString());
                }
            }

            if (currentCandidates.Count() == 0)
            {
                alternativePicker.Title = "Pick from map";
                activePin.Label = "No address found";
                accept.IsEnabled = false;
            }
            else
            {
                alternativePicker.Title = "Select";
                activePin.Label = alternativePicker.Items.First();
                accept.IsEnabled = true;
            }
            alternativePicker.SelectedIndex = 0;
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            pickResult.SetResult(currentCandidates[alternativePicker.SelectedIndex]);
        }

    }
}