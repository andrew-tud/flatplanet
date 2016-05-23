using System;
using System.Web.Mvc;
using CounterProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CounterProjectTests
{
    [TestClass]
    public class HomeControllerTests
    {

        [TestMethod]
        public void Index_PageLoadHomeController_ReturnView()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(string.Empty, result.ViewName);
        }
    }
}
