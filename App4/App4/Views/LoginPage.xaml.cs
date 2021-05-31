using App4.DataBase;
using App4.Validators;
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
                IvalidateUser validator = new ValidateUser();

                bool result = await validator.AuthenticationUser(userNameEntry.Text, passwordEntry.Text);

                if (result)
                {
                    await DisplayAlert("Log In", "Login is successful", "OK");
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