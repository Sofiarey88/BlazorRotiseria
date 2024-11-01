using RoticeriaBlazor.Enums;

namespace RoticeriaBlazor.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Opcional con Firebase
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; } = null;
        
        public bool Eliminado { get; set; } = false;


        public override string ToString()
        {
            return $"{Cliente?.Nombre}" ?? string.Empty;
        }
    }
}

