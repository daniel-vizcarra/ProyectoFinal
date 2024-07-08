using AtticaMAUI.Models;
using AtticaMAUI.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace AtticaMAUI.ViewModels
{
    public class ObradeArtesViewModel : BindableObject
    {
        private readonly ObradeArteService _obraService;
        public ObservableCollection<ObradeArte> Obras { get; } = new ObservableCollection<ObradeArte>();

        public ObradeArtesViewModel(ObradeArteService obraService)
        {
            _obraService = obraService;
            LoadObrasCommand = new Command(async () => await LoadObrasAsync());
        }

        public ICommand LoadObrasCommand { get; }

        public async Task LoadObrasAsync()
        {
            var obras = await _obraService.GetObrasAsync();

            Obras.Clear();
            foreach (var obra in obras)
            {
                Obras.Add(obra);
            }
        }
    }
}
