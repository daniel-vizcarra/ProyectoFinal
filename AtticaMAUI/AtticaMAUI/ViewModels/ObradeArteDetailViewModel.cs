using AtticaMAUI.Models;
using AtticaMAUI.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace AtticaMAUI.ViewModels
{
    public class ObradeArteDetailViewModel : BindableObject
    {
        private readonly ObradeArteService _obraService;
        private ObradeArte _obra;

        public ObradeArteDetailViewModel(ObradeArteService obraService)
        {
            _obraService = obraService;
        }

        public ObradeArte Obra
        {
            get => _obra;
            set
            {
                _obra = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadObraAsync(int id)
        {
            Obra = await _obraService.GetObraAsync(id);
        }
    }
}
