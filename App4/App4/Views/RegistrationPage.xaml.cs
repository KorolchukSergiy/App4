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
using App4.Validators;
using System.ComponentModel.DataAnnotations;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {

        public RegistrationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            emailEntry.ReturnCommand = new Command(() => loginEntry.Focus());
            loginEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
            confirmpasswordEntry.ReturnCommand = new Command(() => phoneEntry.Focus());

            passwordEntry.Focused += (object sender, FocusEventArgs e) => { passwordWarLabel.IsVisible = false; };
            confirmpasswordEntry.Focused += (object sender, FocusEventArgs e) => { confirmPasswordWarLabel.IsVisible = false; };
            phoneEntry.Focused += (object sender, FocusEventArgs e) => { phoneWarLabel.IsVisible = false; };
            loginEntry.Focused += (object sender, FocusEventArgs e) => { loginWarLabel.IsVisible = false; };

        }
        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginEntry.Text) || string.IsNullOrWhiteSpace(emailEntry.Text)
                || string.IsNullOrWhiteSpace(passwordEntry.Text) || string.IsNullOrWhiteSpace(confirmpasswordEntry.Text)
                || string.IsNullOrWhiteSpace(phoneEntry.Text))
            {
                await DisplayAlert("Sing Up", "Please fill in all fields ", "OK");
            }
            else
            {
                User user = CreateUser();
                List<ValidationResult> Errors = await new ValidateUser().ValidateNewUser(user, confirmpasswordEntry.Text);

                if (Errors.Count == 0)
                {

                    await DisplayAlert("Sing Up", "Registration successful", "OK");
                }
                else
                {
                     ShowErrors(Errors);
                }

            }
        }

        private User CreateUser()
        {
            return new User
            {
                email = emailEntry.Text,
                login = loginEntry.Text,
                password = passwordEntry.Text,
                phone = phoneEntry.Text
            };
        }

        private void ShowErrors(List<ValidationResult> Errors)
        {

            Page currentPage = Navigation.NavigationStack.LastOrDefault();
            foreach (var item in Errors)
            {
                currentPage.FindByName<Label>(item.MemberNames.ToArray()[0] + "WarLabel").Text = item.ErrorMessage;
                currentPage.FindByName<Label>(item.MemberNames.ToArray()[0] + "WarLabel").IsVisible = true;
            }

        }


        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}