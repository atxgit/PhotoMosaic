using PhotoMosaic.Models;

namespace PhotoMosaic.DataAccess
{
    public interface IPhotoTagDataAdapter
    {
        PhotoTagModel GetPhotoTag(int id);

        PhotoTagSetModel SearchPhotoTags(SearchCriteriaModel criteria, PagerPageModel page,
            AuthCredentialsModel credentials);

        PhotoTagModel UpdatePhotoTag(int id, string name, string type);
        
        void UpdatePhotoWithTag(int photoId, int tagId);

        void DeleteTagFromPhoto(int photoId, int tagId);

        PhotoTagSetModel GetPhotoTagsByPhoto(int photoId, PagerPageModel page);
    }
}