using App4.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();    
            userNameEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userNameEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Log In", "Enter Login and Password", "OK");
            }
            else
            {
                SQLiteDB Db = new SQLiteDB();
                string login = userNameEntry.Text;
                string password = passwordEntry.Text;

                bool result = await Db.LogIn(login, password);

                if (result)
                {
                    await DisplayAlert("Log In", "Login is successful", "OK");
                    //App.Current.MainPage = new NavigationPage(new UsersPage());
                    await Navigation.PushAsync(new UsersViewPage());
                }
                else
                {
                    await DisplayAlert("Log In", "Login or password is incorected", "OK");
                }
            }
        }
        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}