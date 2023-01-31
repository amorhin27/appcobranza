using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Domain
{
    public class Cobranza
    {
        public int CobranzaId { get; set; }
        public int PrestamoId { get; set; }
        public DateTime? FechaDescuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal MontoSaldo { get; set; }
        [StringLength(500)]
        public string? Detalle { get; set; }
        public bool EstadoCobranza { get; set; }
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
