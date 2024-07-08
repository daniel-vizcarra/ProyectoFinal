using AtticaMAUI.Models;
using AtticaMAUI.Services;
using AtticaMAUI.ViewModels;
using AtticaMAUI.Views;
using Microsoft.Maui.Controls;

namespace AtticaMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly ObradeArtesViewModel _obradeArtesViewModel;
        private readonly ObradeArteService _obraService;

        public MainPage(ObradeArtesViewModel obradeArtesViewModel, ObradeArteService obraService)
        {
            InitializeComponent();
            BindingContext = _obradeArtesViewModel = obradeArtesViewModel;
            _obraService = obraService;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is ObradeArte selectedObra)
            {
                // Crear una instancia de ObradeArteDetailViewModel con la obra seleccionada
                var obraDetailViewModel = new ObradeArteDetailViewModel(_obraService)
                {
                    Obra = selectedObra
                };

                // Pasar el ViewModel en lugar del modelo
                await Navigation.PushAsync(new ObradeArteDetailPage(obraDetailViewModel));
            }
        }
    }
}
