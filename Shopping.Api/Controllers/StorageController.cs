using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Storages;
using Shopping.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService storageService;

        public StorageController(IStorageService storageService) => 
            this.storageService = storageService;

        [HttpGet]
        public async ValueTask<ActionResult<BaseResponse<IEnumerable<Storage>>>> GetAllAsync()
        {
            var entities = await storageService.GetAllAsync();

            return StatusCode(entities.Code ?? entities.Error.Code.Value, entities);
        }
    }
}
