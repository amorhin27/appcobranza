using AppData.Application.Contracts.Persistence.ICobranza;
using AppData.Application.DTOs.CobranzaDto;
using AppData.Domain;
using AppData.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppData.Infrastructure.Repository.RCobranza
{
    public class CobranzaRepository : ICobranzaRepository
    {
        private readonly DataDbContext _context;
        public CobranzaRepository(DataDbContext context) => _context = context;
        public async Task<int> AddCobranza(CreateCobranzaDTO query)
        {
            try
            {

                var detall = await _context.Prestamos.FirstOrDefaultAsync(p => p.PersonaId == query.PersonaId && p.PrestamoId == query.PrestamoId && p.EstadoPrestamo == true);
                var listData = await _context.Cobranzas.FirstOrDefaultAsync(p => p.PrestamoId == query.PrestamoId && p.EstadoCobranza == true);
                decimal dd = (detall == null ? query.MontoDescuento : detall.TotalCredito - query.MontoDescuento);
                if (detall != null)
                {
                    detall.TotalCredito = dd;
                    listData.EstadoCobranza = false;
                    //await _context.SaveChangesAsync();

                    Cobranza cobranza = new Cobranza();
                    cobranza.PrestamoId = query.PrestamoId;
                    cobranza.Detalle = query.Detalle;
                    cobranza.MontoDescuento = query.MontoDescuento;
                    cobranza.MontoSaldo = dd;
                    cobranza.EstadoCobranza = true;

                    _context.Cobranzas.Add(cobranza);
                    return await _context.SaveChangesAsync();
                }
                else { return 0; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> DeleteCobranza(int id)
        {
            throw new NotImplementedException();

        }

        public Task<GetCobranzaDTO> GetCobranza(string nombre)
        {
            try
            {
                var query = (from persona in _context.Personas.Where(x => x.Nombres == nombre && x.Dni == "" && x.Estado == true)
                             join prestamo in _context.Prestamos.Where(x=>x.Estado == true) on persona.PeopleId equals prestamo.PersonaId into leftPrestamo
                             from prestamo in leftPrestamo.DefaultIfEmpty()
                             //join cobranza in _context.Cobranzas on prestamo.PrestamoId equals cobranza.PrestamoId into leftCobranza
                             //from cobranza in leftCobranza.DefaultIfEmpty()
                             select new GetCobranzaDTO()
                             {
                                 PersonaId = persona.PeopleId,
                                 Nombres = persona.Nombres,
                                 NombreCompleto = persona.Nombres +" "+ persona.ApellidoPaterno +" "+ persona.ApellidoMaterno,
                                 Dni = persona.Dni,
                                 Referencia= persona.Referencia,
                                 DeudaTotal = prestamo.Monto,
                                 TotalSaldo = prestamo.TotalCredito,
                                 CobranzaDiario = prestamo.PagoDiario

                             });
                return (Task<GetCobranzaDTO>)query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> UpdateCobranza(CreateCobranzaDTO persona)
        {
            throw new NotImplementedException();
        }
    }
}
