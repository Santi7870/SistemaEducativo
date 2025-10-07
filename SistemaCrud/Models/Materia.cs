using System.ComponentModel.DataAnnotations;


namespace SistemaCrud.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Descripcion { get; set; }
    }
}
