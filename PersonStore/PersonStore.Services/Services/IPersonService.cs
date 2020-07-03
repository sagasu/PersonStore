using System.Collections.Generic;
using System.Threading.Tasks;
using PersonStore.Services.DTO;

namespace PersonStore.Services.Services
{
    public interface IPersonService
    {
        Task<int> CreatePerson(PersonDTO personDto);
        Task<IEnumerable<PersonDTO>> GetAllPeople();
    }
}