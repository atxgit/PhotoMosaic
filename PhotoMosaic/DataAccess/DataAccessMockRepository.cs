using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using PhotoMosaic.Models;

namespace PhotoMosaic.DataAccess
{
    public class DataAccessMockRepository
    {
        private static DataAccessMockRepository _dataAccessMockRepository = null;

        public List<PhotoTagModel> PhotoTags;
        public List<string> Photos_PhotoTags;

        public DataAccessMockRepository()
        {
            // read config
            
            // new data access
            PhotoTags = new List<PhotoTagModel>();
            Photos_PhotoTags = new List<string>();
        }

        public static DataAccessMockRepository GetInstance()
        {
            if (_dataAccessMockRepository == null)
            {
                _dataAccessMockRepository = new DataAccessMockRepository();
            }

            return _dataAccessMockRepository;
        }

    }
}