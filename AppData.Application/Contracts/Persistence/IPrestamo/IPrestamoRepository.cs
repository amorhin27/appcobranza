using AppData.Application.DTOs.PrestamoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Contracts.Persistence.IPrestamo
{
    public interface IPrestamoRepository
    {
        Task<List<GetPrestamoClienteDTO>> GetPrestamo(string dni, string nombres, string direccion, string referencia);
        Task<GetPrestamoDTO> GetPrestamoById(int PersonaId);
        //Task<IEnumerable<Prestamo>> GetPersonaByNombre(string nommbre);
        Task<int> AddPrestamo(CreatePrestamoDTO persona);
        Task<bool> DeletePrestamo(int id);
        Task<bool> UpdatePrestamo(UpdatePrestamoDTO persona);
    }
}
