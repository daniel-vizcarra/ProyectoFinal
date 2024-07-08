namespace AtticaAPI.Models
{
    public class Artista
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Biografia { get; set; }
        public string? ImagenUrl { get; set; }
        public List<ObradeArte>? Obras { get; set; }
    }
}
 