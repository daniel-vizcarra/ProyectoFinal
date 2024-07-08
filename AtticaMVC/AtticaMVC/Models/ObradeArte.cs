namespace AtticaMVC.Models
{
    public class ObradeArte
    {
        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? ArtistaId { get; set; }
        public Artista? Artista { get; set; }
        public string?   ImagenUrl { get; set; }
    }

}
