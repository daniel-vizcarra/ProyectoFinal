using AtticaMAUI.Views;
using Microsoft.Maui.Controls;

namespace AtticaMAUI
{
    public partial class App : Application
    {
        public App(ObradeArtesPage obrasPage)
        {
            InitializeComponent();

            MainPage = new NavigationPage(obrasPage);
        }
    }
}
