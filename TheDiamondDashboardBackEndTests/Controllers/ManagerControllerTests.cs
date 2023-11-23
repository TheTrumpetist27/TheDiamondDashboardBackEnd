using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDiamondDashboardBackEnd.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDiamondDashboardBackEnd.Services.ManagerService;
using TheDiamondDashboardBackEnd.InterfaceFactory;
using TheDiamondDashboardBackEnd.Models;

namespace TheDiamondDashboardBackEnd.Controllers.Tests
{
    [TestClass()]
    public class ManagerControllerTests
    {
        private IManagerService _managerService;
        [TestInitialize]
        public void Setup()
        {
            _managerService = InterfaceCollection.GetTestIManagerService();
        }

        [TestMethod()]
        public void GetAllManagersTest()
        {
            List<Manager> managers = _managerService.GetAllManagers().Result;

            Assert.IsNotNull(managers);
        }
    }
}