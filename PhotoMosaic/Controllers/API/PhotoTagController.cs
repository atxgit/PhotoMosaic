using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoMosaic.Models;
using PhotoMosaic.DataAccess;

namespace PhotoMosaic.Controllers.API
{
    public class PhotoTagController : ApiController
    {
        private IPhotoTagDataAdapter _dataAdapter = DataAccessFactory.GetInstance().PhotoTagDataAdapter;

        // GET api/phototag
        public PhotoTagModel Get(int id)
        {
            return _dataAdapter.GetPhotoTag(id);
        }

        //// GET api/phototag/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/phototag
        public void Post([FromBody]string value)
        {
        }

        // PUT api/phototag/5
        public int Put(int id, string name, string type, int photoId)
        {
            var tag = _dataAdapter.UpdatePhotoTag(id, name, type);
            _dataAdapter.UpdatePhotoWithTag(photoId, tag.Id);

            return tag.Id;
        }

        // PUT api/phototag/5
        public void Put(int id, int photoId)
        {
            _dataAdapter.UpdatePhotoWithTag(photoId, id);
        }

        // DELETE api/phototag/5
        public void Delete(int id, int photoId)
        {
            _dataAdapter.DeleteTagFromPhoto(photoId, id);
        }
    }
}
