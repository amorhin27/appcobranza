using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Domain
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [StringLength(15)]
        public string? Dni { get; set; }
        [StringLength(150)]
        public string? Nombres { get; set; }
        [StringLength(150)]
        public string? ApellidoPaterno { get; set; }
        [StringLength(150)]
        public string? ApellidoMaterno { get; set; }
        [StringLength(150)]
        public DateTime? FechaNacimiento { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        //auditoria
        public bool Estado { get; set; }
        public int CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
