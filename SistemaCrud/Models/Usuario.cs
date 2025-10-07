using System.ComponentModel.DataAnnotations;



namespace SistemaCrud.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, EmailAddress, StringLength(120)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string PasswordSalt { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
