using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Domain
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public int PersonaId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        [StringLength(500)]
        public string? Detalle { get; set; }
        public decimal Monto { get; set; }      
        public decimal TotalCredito { get; set; }      
        public decimal TasaInteres { get; set; }
        public decimal PagoDiario { get; set; }
        public bool EstadoPrestamo { get; set; }
        //auditoria
        public bool Estado { get; set; } 
        public int CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
