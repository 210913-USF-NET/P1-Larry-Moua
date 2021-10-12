using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using WebUI.Controllers;
using RBBL;
using Models;
using WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class ControllerTests
    {
        [Fact]
        public void ArtistControllerIndexShouldReturnListOfArtists()
        {
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllArtist()).Returns(
                new List<Artist>()
                {
                    new Artist()
                    {
                        Id = 1,
                        GroupName = "FANATICS"
                    },
                    new Artist()
                    {
                        Id = 2,
                        GroupName = "LOONA"
                    }
                }
            );
            var controller = new ArtistController(mockBL.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Artist>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void WarehouseControllerIndexShouldReturnListOfWarehouses()
        {
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllWarehouse()).Returns(
                new List<Warehouse>()
                {
                    new Warehouse()
                    {
                        Id = 1,
                        Name = "WarehouseAU",
                        Location = "Melbourne, Australia"
                    },
                    new Warehouse()
                    {
                        Id = 2,
                        Name = "WarehouseBR",
                        Location = "Salvador, Brazil"
                    }
                }
            );
            var controller = new WarehouseController(mockBL.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Warehouse>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}
