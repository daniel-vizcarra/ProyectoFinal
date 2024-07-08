using AtticaMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace AtticaMAUI.Views
{
    public partial class ObradeArtesPage : ContentPage
    {
        private readonly ObradeArtesViewModel _viewModel;

        public ObradeArtesPage(ObradeArtesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadObrasAsync();
        }
    }
}
