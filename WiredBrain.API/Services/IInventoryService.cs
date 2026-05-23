using WiredBrain.API.Services.Models;

namespace WiredBrain.API.Services
{
    public interface IInventoryService
    {
        LocationInventory? GetLocationInventory(int locationId);
    }
}
