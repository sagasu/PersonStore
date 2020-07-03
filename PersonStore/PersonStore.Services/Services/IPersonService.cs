using System.Threading.Tasks;
using PersonStore.Services.DTO;

namespace PersonStore.Services.Services
{
    public interface IPersonService
    {
        Task<int> CreatePerson(PersonDTO personDto);
    }
}