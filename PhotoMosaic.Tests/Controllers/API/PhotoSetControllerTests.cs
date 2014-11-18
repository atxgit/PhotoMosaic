using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoMosaic.Controllers.API;

namespace PhotoMosaic.Tests
{
    [TestClass]
    public class PhotoSetControllerTests
    {
        [TestMethod]
        public void PhotoSetController_ShouldReturnData()
        {
            var SUT = new PhotoSetController();

            int inputData = 10;

            var data = SUT.Get("", 1, inputData, "", "");

            Assert.AreEqual(data.Photos.Count, inputData);
            Assert.AreNotEqual(data,null );
        }

        
    }
}
