using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PersonStore.Services.Data.Creation
{
    public interface IStoreTablesCreationService
    {
        Task Create();
    }

    public class StoreTablesCreationService : IStoreTablesCreationService
    {
        private readonly StoreContext _context;
        

        public StoreTablesCreationService(StoreContext context)
        {
            _context = context;
        }

        public async Task Create()
        {
            const string createPersonsTable =
                "CREATE TABLE Persons (ID int, Name varchar(100), CreateTime datetime)";
            var creation = await _context.Database.ExecuteSqlRawAsync(createPersonsTable);

        }
    }
}
