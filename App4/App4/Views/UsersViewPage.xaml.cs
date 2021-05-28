using App4.DataBase;
using App4.Models;
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
        //IEnumerable<User> sourceData;


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

        public void Edit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", (mi.CommandParameter as User).name + " more context action", "OK");
  
        }
        public void Delete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete", mi.CommandParameter + " more context action", "OK");
        }

    }
}