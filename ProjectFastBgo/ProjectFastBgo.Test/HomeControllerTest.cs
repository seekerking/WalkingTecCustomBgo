using System;
using ProjectFastBgo.Controllers;
using ProjectFastBgo.ViewModel.HomeVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectFastBgo.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;
        private string _seed;

        public HomeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<HomeController>(_seed, "user");
        }

        [TestMethod]
        public void IndexTest()
        {
            ViewResult rv = (ViewResult)_controller.Index();
            //测试是否正确IndexVM
            Assert.IsInstanceOfType(rv.Model, typeof(IndexVM));
        }

        [TestMethod]
        public void PIndexTest()
        {
            ViewResult rv = (ViewResult)_controller.PIndex();
            //测试是否正确返回
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void FrontPageTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.FrontPage();
            //测试是否正确返回
            Assert.IsNotNull(rv);
        }
    }
}
