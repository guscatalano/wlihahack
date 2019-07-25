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
using System.Net.NetworkInformation;
using Plugin.Geolocator.Abstractions;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace WlihaInputUI
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            CameraButtonEviction.Clicked += CameraButtonEviction_ClickedAsync;
            CameraButtonLease.Clicked += CameraButtonLease_ClickedAsync;
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
        {/*
            TenantApi tAPI = new TenantApi("http://neighborevictions.azurewebsites.net/api/Tenant");
            */
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://neighborevictions.azurewebsites.net");
                client.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
               // client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                string data = String.Format(
                @"{{
                    ""tenantInfo"":{{
                        ""Name"":""{0}"",
                        ""Email"":""{1}"",
                        ""Phone"":""{2}"",
                        ""NumberOfPpl"":{3}
                    }},
                    ""addressInfo"":{{
                        ""StreetAddress"":""{4}"",
                        ""Unit"":{5},
                        ""City"":""{6}"",
                        ""County"":""{7}"",
                        ""Zipcode"":{8},
                        ""Latitude"":{9},
                        ""Longitude"":{10}
                    }},
                    ""evictionInfo"":{{
                        ""DateofEviction"":""{11}""
                    }}
                }}", tenantName.Text, tenantEmail.Text, tenantPhone.Text, tenantCount.Text,
                    addrStreet.Text, addrUnit.Text, addrCity.Text, addrCounty.Text, addrZip.Text, "45.1", "45.1",
                    evictionDate.Text);
                /*string data = String.Format(
                @"{{
                    ""tenantInfo"":{{
                        ""Name"":""{0}"",
                        ""Email"":""{1}"",
                        ""Phone"":""{2}"",
                        ""NumberOfPpl"":{3}
                    }},
                    ""addressInfo"":{{
                        ""StreetAddress"":""{4}"",
                        ""Unit"":{5},
                        ""City"":""{6}"",
                        ""County"":""{7}"",
                        ""Zipcode"":{8},
                        ""Latitude"":{9},
                        ""Longitude"":{10}
                    }},
                    ""evictionInfo"":{{
                        ""DateofEviction"":""{11}""
                    }}
                }}", "tony", "tony@tony.tony", 5555555555, 20,
                    "321 tony st", 123, "tonyville", "tonytown", "98008", 45.1, 45.1,
                    "7-24-2019");*/

                StringContent queryString = new StringContent(data, Encoding.UTF8, "application/json");
                var result = client.PostAsync("/api/Tenant", queryString).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    DisplayAlert("Success", "Your submission has been accepted", "OK");
                }
                else {
                    DisplayAlert("Failure", "There was a problem with your submission, please check the fields", "OK");
                }
               // return resultContent;
            }

            //TenantInfo ti = new TenantInfo(null, tenantName.Text, tenantEmail.Text , tenantPhone.Text, Int32.Parse(tenantCount.Text));
            //AddressInfo ai = new AddressInfo(null, addrStreet.Text, Int32.Parse(addrUnit.Text), addrCity.Text, addrCounty.Text, Int32.Parse(addrZip.Text), null, null);
            //EvictionInfo ei = new EvictionInfo(null, Convert.ToDateTime(evictionDate.Text));
            //CompleteTenantEvictionInfo cti = new CompleteTenantEvictionInfo(ti, ai, ei);
            //Configuration config = new Configuration();
            //ApiClient apc = new ApiClient(config);
            //TenantApi tAPI = new TenantApi(config);
            //tAPI.ApiTenantPost(cti);

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

        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            Address hint = new Address()
            {
                streetAndNumber = addrStreet.Text,
                city = addrCity.Text,
                zipcode = addrZip.Text
            };

            Address result = await AddressPicker.ModalPickAddress(Navigation, hint);
            if (result != null)
            {
                addrStreet.Text = result.streetAndNumber;
                addrCity.Text = result.city;
                addrZip.Text = result.zipcode;
            }

        }
    }
}