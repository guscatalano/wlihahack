using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;
using IO.Swagger.Api;
using IO.Swagger.Model;
using IO.Swagger.Client;

namespace WlihaInputUI
{
    public partial class MainPage : TabbedPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public MainPage()
        {
            InitializeComponent();

            CameraButtonEviction.Clicked += CameraButtonEviction_ClickedAsync;
            CameraButtonLease.Clicked += CameraButtonLease_ClickedAsync;

            if (File.Exists(_fileName))
            {
                //street.Text = File.ReadAllText(_fileName);
            }
        }

        private void NextPageTenant_Clicked(object sender, EventArgs e)
        {
            if (orgswitch.IsToggled)
                CurrentPage = orgpage;
            else
                CurrentPage = addrpage;
        }

        private void NextPageOrg_Clicked(object sender, EventArgs e)
        {
            CurrentPage = addrpage;
        }

        private void NextPageAddress_Clicked(object sender, EventArgs e)
        {
            CurrentPage = noticepage;
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            TenantInfo ti = new TenantInfo(null, tenantName.Text, tenantEmail.Text , tenantPhone.Text, Int32.Parse(tenantCount.Text));
            AddressInfo ai = new AddressInfo(null, addrStreet.Text, Int32.Parse(addrUnit.Text), addrCity.Text, addrCounty.Text, Int32.Parse(addrZip.Text), null, null);
            EvictionInfo ei = new EvictionInfo(null, Convert.ToDateTime(evictionDate.Text));
            CompleteTenantEvictionInfo cti = new CompleteTenantEvictionInfo(ti, ai, ei);
            //Configuration config = new Configuration();
            //ApiClient apc = new ApiClient(config);
            //TenantApi tAPI = new TenantApi(config);
            TenantApi tAPI = new TenantApi("http://neighborevictions.azurewebsites.net:44390/api/Tenant");
            tAPI.ApiTenantPost(cti);

            //Org fields
            //orgname
            //orgemail
            //orgphone
        }

        private void Orgswitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (orgswitch.IsToggled)
            {
                orgname.IsEnabled = true;
                orgemail.IsEnabled = true;
                orgphone.IsEnabled = true;
            }
            else {
                orgname.IsEnabled = false;
                orgemail.IsEnabled = false;
                orgphone.IsEnabled = false;
            }
        }

        private async void CameraButtonEviction_ClickedAsync(object sender, EventArgs e) {
            Take_Photo(EvictionPhoto);
        }
        private async void CameraButtonLease_ClickedAsync(object sender, EventArgs e)
        {
            Take_Photo(LeasePhoto);
	}
        async void OnMapTestClicked(object sender, EventArgs e)
        {
            String result = await AddressPicker.ModalPickAddressFromGPS(Navigation);
            await DisplayAlert("Picked Address", result, "OK");
        }

        private async void Take_Photo(Xamarin.Forms.Image imageHolder)
        {/*
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });*/

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        await DisplayAlert("Camera Permission", "Allow SavR to access your camera", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                    status = results[Permission.Camera];
                }

                if (status == PermissionStatus.Granted)
                {

                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        PhotoSize = PhotoSize.Medium,

                    });

                    if (file == null)
                        return;


                    /* using (var memoryStream = new MemoryStream())
                     {
                         file.GetStream().CopyTo(memoryStream);
                         var myfile = memoryStream.ToArray();
                         mysfile = myfile;
                     }

                     PhotoIDImage.Source = ImageSource.FromFile(file.Path);*/
                     imageHolder.Source = ImageSource.FromStream(() => { return file.GetStream(); });


                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Camera Not Available", "OK");
            }



            /*
        var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }*/
        }

        /*void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, street.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            street.Text = string.Empty;
        }*/
    }
}