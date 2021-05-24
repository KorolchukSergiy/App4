using App4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App4.DataBase;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {

        public RegistrationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            emailEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
            confirmpasswordEntry.ReturnCommand = new Command(() => phoneEntry.Focus());
        }
        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(userNameEntry.Text) || string.IsNullOrWhiteSpace(emailEntry.Text)
                || string.IsNullOrWhiteSpace(passwordEntry.Text) || string.IsNullOrWhiteSpace(confirmpasswordEntry.Text)
                || string.IsNullOrWhiteSpace(phoneEntry.Text))
            {
                await DisplayAlert("Sing Up", "Please fill in all fields ", "OK");
            }
            else if (!string.Equals(passwordEntry.Text, confirmpasswordEntry.Text)&& passwordEntry.Text.Length>=6)
            {
                warningLabel.Text = "Enter Same Password";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if (phoneEntry.Text.Length < 10)
            {
                phoneEntry.Text = string.Empty;
                phoneWarLabel.Text = "Enter 10 digit Number";
                phoneWarLabel.TextColor = Color.IndianRed;
                phoneWarLabel.IsVisible = true;
            }
            else
            {
                User users = new User();
                users.name = emailEntry.Text;
                users.userName = userNameEntry.Text;
                users.password = passwordEntry.Text;
                users.phone = phoneEntry.Text.ToString();
                await DisplayAlert("User Add", users.name+ users.userName, "OK");
                SQLiteDB Db = new SQLiteDB();
                bool result = await Db.RegisterUser(users);
                if (result==true)
                {
                    await DisplayAlert("User Add", result.ToString(), "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("User dont Add", "email or login is already in use", "OK");
                }
            }
        }
        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}