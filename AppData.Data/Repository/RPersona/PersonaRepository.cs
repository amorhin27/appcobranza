using AppData.Application.Contracts.Peristence;
using AppData.Application.DTOs.PeopleDto;
using AppData.Domain;
using AppData.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AppData.Infrastructure.Repository.RPersona
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DataDbContext _context;

        public PersonaRepository(DataDbContext context) => _context = context;


        public async Task<int> AddPersona(People persona)
        {
            //var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
            //using (scope)
            //{
            try
            {
                _context.Personas.Add(persona);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            //}
        }

        public async Task<bool> DeletePersona(int id)
        {
            //var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
            //using (scope)
            //{
            try
            {
                var deletePersona = await _context.Personas.FirstOrDefaultAsync(x => x.PeopleId == id);
                int rr = 0;
                if (deletePersona != null)
                {
                    deletePersona.Estado = false;
                    deletePersona.DeleteUser = 1;
                    deletePersona.DeleteDate = DateTime.Now;
                    rr = await _context.SaveChangesAsync();
                }
                bool rt = true;
                if (rr < 1) { rt = false; }
                return rt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
        }

        public async Task<IEnumerable<People>> GetPersonaByNombre(string nombre)
        {

            //List<EquipoGridModel> sqlQuery = (from equipo in _context.T_EQUIPO_INFORMATICO.Where(x => x.ESTADO == "1" && x.IDC_ESTADO_SITUACION == IdcEstadoSituacion)
            //                                  join tipoProducto in _context.T_CONTENEDOR on equipo.IDC_TIPO_EQUIPO equals tipoProducto.ID_CONTENEDOR into lefTipo
            //                                  from tipoProducto in lefTipo.DefaultIfEmpty()
            //                                  join marca in _context.T_CONTENEDOR on equipo.IDC_MARCA_EQUIPO equals marca.ID_CONTENEDOR
            //                                  join estadoSituacion in _context.T_CONTENEDOR on equipo.IDC_ESTADO_SITUACION equals estadoSituacion.ID_CONTENEDOR
            //                                  select new EquipoGridModel
            //                                  {
            //                                      IdEquipoInformatico = equipo.ID_EQUIPO_INFORMATICO,
            //                                      IdcTipoEquipo = equipo.IDC_TIPO_EQUIPO,
            //                                      CodigoPatrimonial = equipo.CODIGO_PATRIMONIAL,
            //                                      FechaInventario = equipo.FECHA_INVENTARIADO,
            //                                      TipoEquipo = tipoProducto.DENOMINACION,
            //                                      MarcaEquipo = marca.DENOMINACION,
            //                                      ModeloEquipo = equipo.MODELO_EQUIPO,
            //                                      NumeroSerie = equipo.NUMERO_SERIE,
            //                                      IdcEstadoSituacion = equipo.IDC_ESTADO_SITUACION,
            //                                      EstadoSituacion = estadoSituacion.DENOMINACION,
            //                                      Valor2 = tipoProducto.VALOR2,
            //                                      FechaCreacion = equipo.FECHA_CREACION,
            //                                      TotalAdjunto = _context.T_ARCHIVO_ADJUNTO.Where(t => t.ID_ORIGEN_ARCHIVO == equipo.ID_EQUIPO_INFORMATICO && t.ESTADO == "1").Select(d => d.ID_ARCHIVO_ADJUNTO).Count()
            //                                  }).OrderByDescending(x => x.IdEquipoInformatico).ToList();

            throw new NotImplementedException();
        }

        public async Task<List<GetPersonaDTO>> GetPersonaAll(string nombre, string dni, string referencia, string direccion)
        {
            //var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
            //using (scope)
            //{
            try
            {
                //var query = await _context.Personas.FirstOrDefaultAsync(x => x.Nombres == nombre);
                // return query;
                #region PERSONA LINQ
                List<GetPersonaDTO> query = (from p in _context.Personas.Where(x => x.Estado== true)
                                             //where p.Nombres == nombre || p.Dni == dni || p.Referencia == referencia || p.Direccion == direccion
                                             select new GetPersonaDTO()
                                             {
                                                 PersonaId = p.PeopleId,
                                                 Dni = p.Dni,
                                                 NombreCompleto = p.Nombres + " " + p.ApellidoPaterno + " "+ p.ApellidoMaterno,
                                                 Nombres= p.Nombres,
                                                 ApellidoPaterno= p.ApellidoPaterno,
                                                 ApellidoMaterno= p.ApellidoMaterno,
                                                 FechaNacimiento= p.FechaNacimiento,
                                                 Direccion = p.Direccion,
                                                 Referencia = p.Referencia,
                                                 Telefono = p.Telefono,
                                                 Correo= p.Correo,
                                             }).OrderByDescending(x => x.NombreCompleto).ToList();
                return query;
                #endregion
            }
            catch (Exception ex)
            {
                //scope.Dispose();
                throw ex;
            }
            //finally { scope.Complete(); }
            //}
        }

        public async Task<bool> UpdatePerosna(UpdatePersonaDTO persona)
        {
            try
            {
                //People people = new People();
                //people.Nombres = persona.Nombres;
                //people.ApellidoPaterno = persona.ApellidoPaterno;
                //people.ApellidoMaterno = persona.ApellidoMaterno;
                //people.Dni = persona.Dni;

                var updatePersona = await _context.Personas.FirstOrDefaultAsync(x => x.PeopleId == persona.PersonaId);
                int rr = 1;
                if (updatePersona != null)
                {
                    updatePersona.Nombres = persona.Nombres;
                    updatePersona.ApellidoPaterno = persona.ApellidoPaterno;
                    updatePersona.ApellidoMaterno = persona.ApellidoMaterno;
                    updatePersona.Dni = persona.Dni;
                    updatePersona.Estado = true;
                    updatePersona.UpdateDate = DateTime.Now;
                    updatePersona.UpdateUser = 1;
                    rr = await _context.SaveChangesAsync();
                }
                bool rt = true;
                if (rr < 1) { rt = false; }
                return rt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<People> GetPeopleById(int id)
        {
            var people = await _context.Personas.FirstOrDefaultAsync(x => x.PeopleId == id);
            return people;
        }

        public async Task<GetDniPersonaDTO> GetPersonaDNI(string DNI)
        {
            try
            {
                var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Dni == DNI);
                if (persona != null)
                {
                    GetDniPersonaDTO getDni = new GetDniPersonaDTO
                    {
                        PersonaId = persona.PeopleId,
                        Nombres = persona.Nombres,
                        ApellidoPaterno = persona.ApellidoPaterno,
                        ApellidoMaterno = persona.ApellidoMaterno,
                        Dni = persona.Dni,
                        Celular = persona.Telefono
                    };
                    return getDni;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GetDniPersonaDTO> GetPersonaById(int Id)
        {
            try
            {
                var persona = await _context.Personas.FirstOrDefaultAsync(x => x.PeopleId == Id);
                GetDniPersonaDTO getDni = new GetDniPersonaDTO
                {
                    PersonaId = persona.PeopleId,
                    Nombres = persona.Nombres,
                    ApellidoPaterno = persona.ApellidoPaterno,
                    ApellidoMaterno = persona.ApellidoMaterno,
                    Dni = persona.Dni,
                    Celular = persona.Telefono
                };
                return getDni;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
