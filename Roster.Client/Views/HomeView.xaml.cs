using Roster.Client.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Roster.Client.Views
{
    [DesignTimeVisible(false)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}