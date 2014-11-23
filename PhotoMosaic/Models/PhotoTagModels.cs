using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PhotoMosaic.Models
{

    public class PhotoTagModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    public class PhotoTagSetModel
    {
        [DataMember]
        public List<PhotoTagModel> PhotoTags { get; set; }


        public PagerPageModel Page { get; set; }

        public PhotoTagSetModel()
        {
            PhotoTags = new List<PhotoTagModel>();
        }
    }
}