using Microsoft.AspNetCore.Mvc;
using WiredBrain.API.Services;

namespace WiredBrain.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryService inventoryService) : ControllerBase
    {

        [HttpGet("{locationId}")]
        public IActionResult GetLocationInventory(int locationId)
        {
            var inventory = inventoryService.GetLocationInventory(locationId);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }
    }
}
