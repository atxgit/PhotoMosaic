using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoMosaic.Models;

namespace PhotoMosaic.DataAccess
{
  
    public class PhotoSetDataAdapterMock : IPhotoSetDataAdapter
    {
        public PhotoModel GetPhoto(int id, AuthCredentialsModel credentials)
        {
            return new PhotoModel()
            {
                Id = id, // random ID
                Url = "https://d2k1ftgv7pobq7.cloudfront.net/images/backgrounds/ocean/large.jpg"
            };
        }


        public PhotoSetModel GetPhotoSet(SearchCriteriaModel criteria, PagerPageModel page,
            AuthCredentialsModel credentials)
        {
            var set = new PhotoSetModel();
            
            set.Page = page;
            set.Photos = new List<PhotoModel>();

            for (int i = PagerPageModel.FIRST_PAGE_INDEX; i <= page.Size; i++)
            {

                set.Photos.Add(new PhotoModel()
                            {
                                Id = i+1000, // random ID
                                Url = "https://d2k1ftgv7pobq7.cloudfront.net/images/backgrounds/ocean/large.jpg"
                            }
                    );
            }

            return set;
        }




    }
}