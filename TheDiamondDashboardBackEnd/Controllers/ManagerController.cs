using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheDiamondDashboardBackEnd.Services.ManagerService;

namespace TheDiamondDashboardBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Manager>>> GetAllManagers()
        {   
            return await _managerService.GetAllManagers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetSingleManager(int id)
        {
            var result = await _managerService.GetSingleManager(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Manager>>> AddManager(Manager manager)
        {
            var result = await _managerService.AddManager(manager);
            return result;
        }

        [HttpPut]
        public async Task<ActionResult<List<Manager>>> UpdateManager(Manager request)
        {
            var result = await _managerService.UpdateManager(request);
            if (result == null)
            {
                return NotFound("This manager does not exist.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Manager>>> DeleteManager(int id)
        {
            var result = await _managerService.DeleteManager(id);
            if (result == null)
            {
                return NotFound("This manager does not exist.");
            }
            return Ok(result);
        }
    }
}
