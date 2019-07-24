using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WlihaInputUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPicker : ContentPage
    {
        private Pin activePin;
        private Geocoder geocoder;
        private TaskCompletionSource<string> pickResult;

        public static async Task<string> ModalPickAddressFromGPS(INavigation where)
        {
            var picker = new AddressPicker();

            await where.PushModalAsync(picker, true);
            var result = await picker.pickResult.Task;
            await where.PopModalAsync();
            return result;
        }

        public AddressPicker()
        {
            InitializeComponent();

            activePin = new Pin();
            geocoder = new Geocoder();
            pickResult = new TaskCompletionSource<string>();

            map.Tap += Map_Tap;

        }

        private void Map_Tap(object sender, TapEventArgs e)
        {
            activePin.Position = e.Position;
            activePin.Label = "Fetching address ...";
            activePin.Type = PinType.Place;

            if (!map.Pins.Contains(activePin))
            {
                map.Pins.Add(activePin);
            }
            geocoder.GetAddressesForPositionAsync(e.Position).ContinueWith(
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
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            pickResult.SetResult((string)alternativePicker.SelectedItem);
        }
    }
}