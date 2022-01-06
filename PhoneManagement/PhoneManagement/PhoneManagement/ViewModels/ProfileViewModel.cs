using Newtonsoft.Json;
using PhoneManagement.Models;
using PhoneManagement.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneManagement.ViewModels
{
    class ProfileViewModel: INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ProfileModel profile;
        public ProfileModel Profile
        {
            get { return profile; }
            set { profile = value;
                OnPropertyChanged("Profile");
            }
        }


        async void GetProfileByID()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/TestController/GetAccountWithID?id=1");
            var dsPF = JsonConvert.DeserializeObject<List<ProfileModel>>(chuoi);
            for (int i = 0; i < dsPF.Count; i++)
            {
                Profile = dsPF[i];
            }

        }
     
        public ICommand UpdateProfileCommand { get; set; }

        async void UpdateProfileFunction()
        {

            HttpClient http = new HttpClient();

            string json = JsonConvert.SerializeObject(Profile);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var chuoi = await http.PutAsync("http://www.wjbu-project.somee.com/api/CartController/UpdateProfile", content);
            await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        }
     
        public ProfileViewModel()
        {
            GetProfileByID();
            UpdateProfileCommand = new Command(UpdateProfileFunction);
        }

    }
}
