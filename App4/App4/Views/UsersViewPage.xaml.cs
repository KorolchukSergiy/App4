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

    }
}