using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinPlayoffsSample.ViewModels;

namespace XamarinPlayoffsSample.Pages
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            BindingContext = new SecondViewModel();
        }
    }
}
