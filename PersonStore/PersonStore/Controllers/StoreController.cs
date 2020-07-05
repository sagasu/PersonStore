using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonStore.Services.Data.Creation;

namespace PersonStore.Controllers
{
    [ApiController]
    [Route("stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreTablesCreationService _storeTablesCreationService;

        public StoreController(IStoreTablesCreationService storeTablesCreationService)
        {
            _storeTablesCreationService = storeTablesCreationService;
        }

        [HttpPut]
        public async Task<OkResult> Create()
        {
            await _storeTablesCreationService.Create();
            return Ok();
        }
    }
}
