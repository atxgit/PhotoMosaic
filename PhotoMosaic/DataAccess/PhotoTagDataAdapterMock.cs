using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using PhotoMosaic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMosaic.DataAccess
{

    public class PhotoTagDataAdapterMock : IPhotoTagDataAdapter
    {
        private DataAccessMockRepository _mockDataRep = DataAccessMockRepository.GetInstance();

        public PhotoTagModel GetPhotoTag(int id)
        {
            var data = new PhotoTagModel() { Id = id, Name = string.Format("Tag Name {0}", id), Type = "Type"};

            return data;
        }

        public PhotoTagSetModel SearchPhotoTags(SearchCriteriaModel criteria, PagerPageModel page,
            AuthCredentialsModel credentials)
        {
            var set = new PhotoTagSetModel();

            set.Page = page;
            set.PhotoTags = new List<PhotoTagModel>();

            for (int i = PagerPageModel.FIRST_PAGE_INDEX; i <= page.Size; i++)
            {
                set.PhotoTags.Add(new PhotoTagModel()
                        {
                            Name = string.Format("Tag Name {0}", i)
                        }
                    );
            }

            return set;
        }

        public PhotoTagSetModel GetPhotoTagsByPhoto(int photoId, PagerPageModel page)
        {
            var set = new PhotoTagSetModel();
            lock (_mockDataRep)
            {
                var p_pt =
                    _mockDataRep.Photos_PhotoTags.Where(x => x.StartsWith(string.Format("{0}x", photoId.ToString())));
                foreach ( var t in p_pt )
                {
                    int tagid = int.Parse(t.Replace(string.Format("{0}x", photoId.ToString()),""));
                    var ptm = _mockDataRep.PhotoTags.First(x => x.Id == tagid);

                    set.PhotoTags.Add( ptm );
                }
            }
            return set;
        }
        
        public PhotoTagModel UpdatePhotoTag(int id, string name, string type)
        {
            PhotoTagModel tag = null;

            lock (_mockDataRep)
            {
                tag = _mockDataRep.PhotoTags.FirstOrDefault(x => x.Id == id);

                if (tag == null)
                {
                    tag = new PhotoTagModel() {Id = (int) DateTime.Now.Ticks, Name = name, Type = type};
                    _mockDataRep.PhotoTags.Add(tag);
                }
                else
                {
                    // -- update fields ---
                    tag.Name = name;
                    tag.Type = type;
                }
            }

            return tag;
        }

        public void UpdatePhotoWithTag(int photoId, int tagId)
        {
            lock (_mockDataRep)
            {
                var uniquePairStr = string.Format("{0}x{1}", photoId, tagId);

                if (!_mockDataRep.Photos_PhotoTags.Contains(uniquePairStr))
                {
                    _mockDataRep.Photos_PhotoTags.Add(uniquePairStr);
                }
            }
        }

        public void DeleteTagFromPhoto(int photoId, int tagId)
        {
            lock (_mockDataRep)
            {
                var uniquePairStr = string.Format("{0}x{1}", photoId, tagId);

                if (_mockDataRep.Photos_PhotoTags.Contains(uniquePairStr))
                {
                    _mockDataRep.Photos_PhotoTags.Remove(uniquePairStr);

                    // -- if this is the last instance of this tag, remove the tag ---
                    if (_mockDataRep.Photos_PhotoTags.Count(x => x.EndsWith(string.Format("x{0}", tagId))) == 0)
                    {
                        _mockDataRep.PhotoTags.RemoveAll(x => x.Id == tagId);
                    }
                }
            }
        }

    }
}