using AppData.Application.DTOs.PeopleDto;
using AppData.Domain;

namespace AppData.Application.Contracts.Peristence
{
    public interface IPersonaRepository //: IAsyncRepository<Persona>
    {
        Task<List<GetPersonaDTO>> GetPersonaAll(string nommbre,string dni, string referencia, string direccion);
        Task<GetDniPersonaDTO> GetPersonaDNI(string DNI);
        Task<GetDniPersonaDTO> GetPersonaById(int id);
        Task<IEnumerable<People>> GetPersonaByNombre(string nommbre);
        Task<int> AddPersona(People persona);
        Task<bool> DeletePersona(int id);
        Task<bool> UpdatePerosna(UpdatePersonaDTO persona);
    }
}
