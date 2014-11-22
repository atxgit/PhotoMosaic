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
                Group = "C and D Photos",
                GroupColor = "#ffaa22",
                Url = "https://d2k1ftgv7pobq7.cloudfront.net/images/backgrounds/ocean/large.jpg"
            };
        }


        public PhotoSetModel GetPhotoSet(SearchCriteriaModel criteria, PagerPageModel page,
            AuthCredentialsModel credentials)
        {
            var set = new PhotoSetModel();
            
            set.Page = page;
            set.Photos = new List<PhotoModel>();

            int lastGroupI = 0;
            int rndI = rnd.Next(1, 10);
            string color = colors[0];

            for (int i = PagerPageModel.FIRST_PAGE_INDEX; i <= page.Size; i++)
            {
                if (i > lastGroupI + rndI)
                {
                    color = colors[i%colors.Count];
                    rndI = rnd.Next(1, 10);
                    lastGroupI = i;
                }

                set.Photos.Add(new PhotoModel()
                            {
                                Id = i + 1000, // random ID
                                Group = color,
                                GroupColor = color,
                                Url = "https://d2k1ftgv7pobq7.cloudfront.net/images/backgrounds/ocean/large.jpg"
                            }
                    );
            }

            return set;
        }

        private List<string> colors = new List<string>() { "#ffaacc", "#ccaa44", "#bbaaff", "#ff33cc", "#aa3322" };
        private Random rnd = new Random();

    }
}