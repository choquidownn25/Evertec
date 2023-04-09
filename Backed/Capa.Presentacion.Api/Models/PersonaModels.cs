using Capa.Conexion.Models;
using Microsoft.AspNetCore.Http;

namespace Capa.Presentacion.Api.Models
{
    public class PersonaModels : Persona
    {
        public IFormFile file { get; set; }
        public bool Success { get; set; } = true;
        public string? ErrorCode { get; set; } = null;
        public string? ErrorMessage { get; set; } = null;
    }
}
