using Microsoft.AspNetCore.Mvc;
using Moq;
using WiredBrain.API.Controllers;
using WiredBrain.API.Services;
using WiredBrain.API.Services.Models;

namespace WiredBrain.Tests
{
    [TestClass]
    public sealed class InventoryControllerTests
    {
        [TestMethod]
        public void GetWithValidID_Returns_200WithJson()
        {
            var mockService = new Mock<IInventoryService>();
            mockService
                .Setup(service => service.GetLocationInventory(It.IsAny<int>()))
                .Returns((int id) => new LocationInventory
                {
                    Id = id,
                    LocationName = "Main Street",
                    KgDarkRoast = 5.8m,
                    KgLightRoast = 10.0m,
                    KgMediumRoast = 7.5m,
                    KgSeasonalRoast = 0.0m
                }
            );

            var controller = new InventoryController(mockService.Object);
            var result = controller.GetLocationInventory(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetWithInvalidID_Returns_NotFound()
        {
            var mockService = new Mock<IInventoryService>();
            mockService
                .Setup(service => service.GetLocationInventory(It.IsAny<int>()))
                .Returns((int id) => null);

            var controller = new InventoryController(mockService.Object);
            var result = controller.GetLocationInventory(-1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
