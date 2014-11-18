using PhotoMosaic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMosaic.DataAccess
{

    public interface IPhotoSetDataAdapter
    {
        PhotoModel GetPhoto(int id, AuthCredentialsModel credentials);

        PhotoSetModel GetPhotoSet(SearchCriteriaModel criteria, PagerPageModel page,
            AuthCredentialsModel credentials);
    }

}