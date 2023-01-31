
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Domain
{
    public class People
    {
        public int PeopleId { get; set; }
        //[Column(TypeName = "NVARCHAR")]
        [StringLength(15)]
        public string? Dni { get; set; }
        [StringLength(200)]
        public string? Nombres { get; set; }
        [StringLength(200)]
        public string? ApellidoPaterno { get; set; }
        [StringLength(200)]
        public string? ApellidoMaterno { get; set; }
        [StringLength(600)]
        public string? NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(500)]
        public string? Direccion { get; set; } 
        [StringLength(500)]
        public string? Referencia { get; set; }
        [StringLength(15)]
        public string? Telefono { get; set; }
        [StringLength(250)]
        public string? Correo { get; set; }
        //auditoria
        public bool Estado { get; set; }
        public int CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
    public class UpdatePeople
    {
        public int PersonaId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
    }
}
