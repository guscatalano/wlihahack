using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

namespace WlihaInputUI
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public MainPage()
        {
            InitializeComponent();

#if DEBUG
            DebugControls.IsVisible = true;
#endif
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }

        async void OnMapTestClicked(object sender, EventArgs e)
        {
            String result = await AddressPicker.ModalPickAddressFromGPS(Navigation);
            await DisplayAlert("Picked Address", result, "OK");
        }
    }
}