using PhotoMosaic.DataAccess;
using PhotoMosaic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoMosaic.Controllers.API
{
    public class PhotoTagSetController : ApiController
    {
        private IPhotoTagDataAdapter _dataAdapter = DataAccessFactory.GetInstance().PhotoTagDataAdapter;
        
        public PhotoTagSetModel Get(string criteriaString, int pageIndex, int pageSize, string authToken, string authDevice)
        {
            var criteria = new SearchCriteriaModel() { SearchString = criteriaString };
            var page = new PagerPageModel() { Index = pageIndex, Size = pageSize };
            var auth = new AuthCredentialsModel() { Email = "", Token = authToken };

            return _dataAdapter.SearchPhotoTags(criteria, page, auth);
        }

        //////// POST api/phototag
        //////public void Post([FromBody]string value)
        //////{
        //////}

        //////// PUT api/phototag/5
        //////public void Put(int id, [FromBody]string value)
        //////{
        //////}

        //////// DELETE api/phototag/5
        //////public void Delete(int id)
        //////{
        //////}
    }
}
