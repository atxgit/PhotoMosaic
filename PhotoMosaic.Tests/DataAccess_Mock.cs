using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoMosaic.Controllers.API;
using PhotoMosaic.DataAccess;
using PhotoMosaic.Models;


namespace PhotoMosaic.Tests
{
    [TestClass]
    public class DataAccess_Mock
    {
        IPhotoSetDataAdapter _psSUT = new PhotoSetDataAdapterMock();
        IPhotoTagDataAdapter _ptSUT = new PhotoTagDataAdapterMock();
        
        [TestMethod]
        public void PhotoSetDataAdapter_Photo_ShouldReturnData()
        {
            int inputValue = 12;

            var data = _psSUT.GetPhoto(inputValue, null);

            Assert.AreNotEqual(data,null);
            Assert.AreNotEqual(data.Url, "");
            Assert.AreEqual(data.Id, inputValue);
        }


        [TestMethod]
        public void PhotoSetDataAdapter_PhotoSet_ShouldReturnData()
        {
            int inputData = 10;
            var data = _psSUT.GetPhotoSet( new SearchCriteriaModel(), new PagerPageModel() {Index=1, Size=inputData}, null );

            Assert.AreNotEqual(data, null);
            Assert.AreEqual(data.Page.Size, inputData);
            Assert.AreEqual(data.Photos.Count, inputData);
        }

        [TestMethod]
        public void PhotoTagDataAdapter_PhotoTagSet_ShouldReturnData()
        {
            int inputData = 10;
            var data = _ptSUT.SearchPhotoTags(new SearchCriteriaModel(), new PagerPageModel() { Index = 1, Size = inputData }, null);

            Assert.AreNotEqual(data, null);
            Assert.AreEqual(data.Page.Size, inputData);
            Assert.AreEqual(data.PhotoTags.Count, inputData);
        }

        [TestMethod]
        public void PhotoTagDataAdapter_PhotoTag_ShouldReturnData()
        {
            int inputData = 10;
            var data = _ptSUT.SearchPhotoTags(new SearchCriteriaModel(), new PagerPageModel() { Index = 1, Size = inputData }, null);

            Assert.AreNotEqual(data, null);
            Assert.AreEqual(data.Page.Size, inputData);
            Assert.AreEqual(data.PhotoTags.Count, inputData);
        }


        [TestMethod]
        public void PhotoTagDataAdapter_PhotoTag_ShouldUpdatePhotoTag()
        {
            var typeData = "Person";

            var tag1 = _ptSUT.UpdatePhotoTag(200, "My New Tag", typeData);

            Assert.AreNotEqual(tag1, null);
            Assert.AreNotEqual(tag1.Id, 200); // first time new tag should be created
            Assert.AreEqual(tag1.Type, typeData);

            typeData = "Theme";
            var tag2 = _ptSUT.UpdatePhotoTag(tag1.Id, "My New Tag", typeData);

            Assert.AreEqual(tag1.Id, tag2.Id); // second time these should match;
            Assert.AreEqual(tag2.Type, typeData);
        }



        [TestMethod]
        public void PhotoTagDataAdapter_PhotoTag_ShouldAddTagsToPhotos()
        {
            var photoId = 300;

            var tag1 = _ptSUT.UpdatePhotoTag(-1, "My New Tag", "Person");
            _ptSUT.UpdatePhotoWithTag(photoId, tag1.Id);

            var photos = _ptSUT.GetPhotoTagsByPhoto(photoId, null);

            Assert.AreEqual(photos.PhotoTags.Count, 1);

            _ptSUT.UpdatePhotoWithTag(photoId, tag1.Id);

            photos = _ptSUT.GetPhotoTagsByPhoto(photoId, null);

            Assert.AreEqual(photos.PhotoTags.Count, 1);

            var tag2 = _ptSUT.UpdatePhotoTag(-1, "My New Tag2", "Person");
            _ptSUT.UpdatePhotoWithTag(photoId, tag2.Id);

            photos = _ptSUT.GetPhotoTagsByPhoto(photoId, null);

            Assert.AreEqual(photos.PhotoTags.Count, 2);
        }



    }
}
