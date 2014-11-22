using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using PhotoMosaic.DataAccess;
using System.Web.Mvc;
using PhotoMosaic.Models;

namespace PhotoMosaic.Controllers.API
{
    public class PhotoSetController : ApiController
    {
        private IPhotoSetDataAdapter _dataAdapter = DataAccessFactory.GetInstance().PhotoSetDataAdapter;

        // GET api/imageset
        public PhotoSetModel Get( string criteriaString, int pageIndex, int pageSize, string authToken, string authDevice)
        {
            var criteria = new SearchCriteriaModel() {SearchString = criteriaString};
            var page = new PagerPageModel() {Index = pageIndex, Size = pageSize};
            var auth = new AuthCredentialsModel() {Email = "", Token = authToken};

            return _dataAdapter.GetPhotoSet( criteria, page, auth);
        }

        // GET api/imageset/5
        public PhotoSetModel Get()
        {
            var criteria = new SearchCriteriaModel() { SearchString = "" };
            var page = new PagerPageModel() { Index = 1, Size = 10 };
            var auth = new AuthCredentialsModel() { Email = "", Token = "" };

            return _dataAdapter.GetPhotoSet(criteria, page, auth);
        }

    }
}
