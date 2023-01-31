
using AppData.Application.DTOs.CobranzaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Contracts.Persistence.ICobranza
{
    public interface ICobranzaRepository
    {
        Task<GetCobranzaDTO> GetCobranza(string nommbre);
        //Task<IEnumerable<Prestamo>> GetPersonaByNombre(string nommbre);
        Task<int> AddCobranza(CreateCobranzaDTO persona);
        Task<bool> DeleteCobranza(int id);
        Task<bool> UpdateCobranza(CreateCobranzaDTO persona);
    }
}
