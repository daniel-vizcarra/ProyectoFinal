using AtticaMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace AtticaMAUI.Views
{
    [QueryProperty(nameof(ObraId), "obraId")]
    public partial class ObradeArteDetailPage : ContentPage
    {
        private readonly ObradeArteDetailViewModel _viewModel;

        public ObradeArteDetailPage(ObradeArteDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        private int obraId;

        public int ObraId
        {
            get => obraId;
            set
            {
                obraId = value;
                LoadObra(value);
            }
        }

        private async void LoadObra(int id)
        {
            await _viewModel.LoadObraAsync(id);
        }
    }
}
