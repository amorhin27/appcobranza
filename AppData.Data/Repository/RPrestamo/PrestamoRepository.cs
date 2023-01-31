using AppData.Application.Contracts.Persistence.IPrestamo;
using AppData.Application.DTOs.PrestamoDto;
using AppData.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AppData.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Application.Features.Persona.Queries.GetPersonaList;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppData.Infrastructure.Repository.RPrestamo
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly DataDbContext _context;
        public PrestamoRepository(DataDbContext context) => _context = context;
        public async Task<int> AddPrestamo(CreatePrestamoDTO query)
        {
            try
            {
                Prestamo prestamo = new Prestamo();
                prestamo.PersonaId = query.PersonaId;
                //prestamo.FechaPrestamo = DateTime.Now();
                prestamo.Detalle = query.Detalle;
                prestamo.Monto = query.Monto;
                prestamo.TasaInteres = query.TasaInteres;
                prestamo.PagoDiario = query.PagoDiario;
                prestamo.EstadoPrestamo = true;
                var updatePrestamo = await _context.Prestamos.FirstOrDefaultAsync(p => p.PersonaId == query.PersonaId);
                if (updatePrestamo != null)
                {
                    updatePrestamo.EstadoPrestamo = false;
                    await _context.SaveChangesAsync();
                }

                _context.Prestamos.Add(prestamo);
                return await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> DeletePrestamo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetPrestamoClienteDTO>> GetPrestamo(string dni, string nombres, string direccion, string referencia)
        {
            try
            {
                var query = (from p1 in _context.Personas.Where(x => x.Estado == true)
                             join p2 in _context.Prestamos.Where(x => x.EstadoPrestamo == true) on p1.PeopleId equals p2.PersonaId
                             //into lefPrestamo from p2 in lefPrestamo.DefaultIfEmpty()
                             join p3 in _context.Cobranzas.Where(x => x.EstadoCobranza == true) on p2.PrestamoId equals p3.PrestamoId
                             where 
                             p1.Nombres == nombres 
                             || p1.Dni == dni
                             || p1.Direccion == direccion
                             || p1.Referencia == referencia
                             select new GetPrestamoClienteDTO
                             {
                                 PersonaId = p1.PeopleId,
                                 NombreCompleto = p1.Nombres,
                                 Dni = p1.Dni,
                                 Direccion = p1.Direccion,
                                 Referencia = p1.Referencia,
                                 TotalCredito = p3.MontoSaldo,
                                 FechaCobranza = p2.FechaPrestamo.ToString("yyyy-mm-dd HH:mm:ss")
                             }).OrderByDescending(x => x.PersonaId).ToList();



                //var sqlQuery = (from equipo in _context.T_EQUIPO_INFORMATICO.Where(x => x.ESTADO == "1" && x.IDC_ESTADO_SITUACION == IdcEstadoSituacion)
                //                join tipoProducto in _context.T_CONTENEDOR on equipo.IDC_TIPO_EQUIPO equals tipoProducto.ID_CONTENEDOR into lefTipo
                //                from tipoProducto in lefTipo.DefaultIfEmpty()
                //                join marca in _context.T_CONTENEDOR on equipo.IDC_MARCA_EQUIPO equals marca.ID_CONTENEDOR
                //                join estadoSituacion in _context.T_CONTENEDOR on equipo.IDC_ESTADO_SITUACION equals estadoSituacion.ID_CONTENEDOR
                //                select new GetPrestamoClienteDTO
                //                {
                //                    IdEquipoInformatico = equipo.ID_EQUIPO_INFORMATICO,
                //                    IdcTipoEquipo = equipo.IDC_TIPO_EQUIPO,
                //                    CodigoPatrimonial = equipo.CODIGO_PATRIMONIAL,
                //                    FechaInventario = equipo.FECHA_INVENTARIADO,
                //                    TipoEquipo = tipoProducto.DENOMINACION,
                //                    MarcaEquipo = marca.DENOMINACION,
                //                    ModeloEquipo = equipo.MODELO_EQUIPO,
                //                    NumeroSerie = equipo.NUMERO_SERIE,
                //                    IdcEstadoSituacion = equipo.IDC_ESTADO_SITUACION,
                //                    EstadoSituacion = estadoSituacion.DENOMINACION,
                //                    Valor2 = tipoProducto.VALOR2,
                //                    FechaCreacion = equipo.FECHA_CREACION,
                //                    TotalAdjunto = _context.T_ARCHIVO_ADJUNTO.Where(t => t.ID_ORIGEN_ARCHIVO == equipo.ID_EQUIPO_INFORMATICO && t.ESTADO == "1").Select(d => d.ID_ARCHIVO_ADJUNTO).Count()
                //                }).OrderByDescending(x => x.IdEquipoInformatico).ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetPrestamoDTO> GetPrestamoById(int PersonaId)
        {
            try
            {
                var prestamo = await _context.Prestamos.FirstOrDefaultAsync(x => x.PersonaId == PersonaId && x.EstadoPrestamo == true);
                GetPrestamoDTO getprestamo = new GetPrestamoDTO();
                if (prestamo != null)
                {
                    //GetPrestamoDTO getprestamo = new GetPrestamoDTO
                    //{
                    getprestamo.PrestamoId = prestamo.PrestamoId;
                    getprestamo.PersonaId = prestamo.PersonaId;
                    getprestamo.FechaPrestamo = prestamo.FechaPrestamo;
                    getprestamo.Detalle = prestamo.Detalle;
                    getprestamo.Monto = prestamo.Monto;
                    getprestamo.TasaInteres = prestamo.TasaInteres;
                    getprestamo.PagoDiario = prestamo.PagoDiario;
                    getprestamo.EstadoPrestamo = prestamo.EstadoPrestamo;
                    //};
                }
                return getprestamo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> UpdatePrestamo(UpdatePrestamoDTO persona)
        {
            throw new NotImplementedException();
        }
    }
}
