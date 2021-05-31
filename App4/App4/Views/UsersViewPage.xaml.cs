using App4.DataBase;
using App4.Models;
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
    public partial class UsersViewPage : ContentPage
    {
 
        public UsersViewPage()
        {
            
            InitializeComponent();
            Loaded();
             
        }

        async void Loaded()
        {
            SQLiteDB userData = new SQLiteDB();            
            listUsers.ItemsSource = await userData.GetUsers();
        }

        private async void Edit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            await DisplayAlert("More Context Action", (mi.CommandParameter as User).Id + " more context action", "OK");
        }
        private async void Delete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            bool accept = await DisplayAlert("Delete" ,"You want delete user : "+ (mi.CommandParameter as User).email +"?", "Yes","No");
            if (accept)
            {
                IvalidateUser validator = new ValidateUser();
                bool result = await validator.DeleteUser((mi.CommandParameter as User).Id);
                if (result)
                {
                    await DisplayAlert("Delete ", "User: " + (mi.CommandParameter as User).email + " has been deleted", "OK");
                    Loaded();
                }
                else
                {
                    await DisplayAlert("Delete ", "User: " + (mi.CommandParameter as User).email + " could not be deleted ", "OK");
                }
            }
        }

    }
}