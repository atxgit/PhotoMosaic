using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMosaic.DataAccess
{
    public class DataAccessFactory
    {
        private static DataAccessFactory _dataAccessFactory = null;

        public IPhotoSetDataAdapter PhotoSetDataAdapter;
        public IPhotoTagDataAdapter PhotoTagDataAdapter;

        public DataAccessFactory()
        {
            // read config
            
            // new data access
            PhotoSetDataAdapter = new PhotoSetDataAdapterMock();
            PhotoTagDataAdapter = new PhotoTagDataAdapterMock();

        }

        public static DataAccessFactory GetInstance()
        {
            if (_dataAccessFactory == null)
            {
                _dataAccessFactory = new DataAccessFactory();
            }

            return _dataAccessFactory;
        }

    }
}