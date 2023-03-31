using System.ComponentModel.DataAnnotations;

namespace abccCoppel.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string Articulo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public DateOnly FechaAlta { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int Descontinuado { get; set; }
        [Required]
        public int DepartamentoId { get; set; }
        [Required]
        public int ClaseId { get; set; }
        [Required]
        public int FamiliaId { get; set; }
    }
}
