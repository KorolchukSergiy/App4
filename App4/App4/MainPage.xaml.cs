using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App4.Views;

namespace App4
{
    public partial class MainPage : Xamarin.Forms.Shell
    {
        public MainPage()
        {
            InitializeComponent();
          
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//StartPage");
        }
    }
}
