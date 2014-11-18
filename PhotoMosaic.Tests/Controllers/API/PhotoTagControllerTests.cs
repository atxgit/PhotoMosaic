using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoMosaic.Controllers.API;

namespace PhotoMosaic.Tests.Controllers.API
{
    [TestClass]
    public class PhotoTagControllerTests
    {
        [TestMethod]
        public void PhotoTagController_ShouldReturnData()
        {
            var SUT = new PhotoTagSetController();

            int inputData = 10;

            var data = SUT.Get("", 1, inputData, "", "");

            Assert.AreEqual(data.PhotoTags.Count, inputData);
            Assert.AreNotEqual(data, null);
        }
    }
}
