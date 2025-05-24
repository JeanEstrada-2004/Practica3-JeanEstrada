using System;

namespace Practica3_JeanEstrada.Models
{
    public class Feedback
    {
        public int Id { get; set; } // Clave primaria
        public int PostId { get; set; }
        public string Sentimiento { get; set; } // "like" o "dislike"
        public DateTime Fecha { get; set; }
    }
}
