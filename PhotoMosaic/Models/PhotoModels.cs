using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace PhotoMosaic.Models
{
    //[DataContract]
    //[Serializable]
    public class PhotoModel
    {
        //[Required]
        //[Display(Name = "Photo Identifier")]
        [DataMember]
        public int Id { get; set; }

        //[Required]
        //[Display(Name = "Photo URL")]
        [DataMember]
        public string Url { get; set; }

        //[Required]
        //[Display(Name = "Group Name")]
        [DataMember]
        public string Group { get; set; }

        //[Required]
        //[Display(Name = "Group Name")]
        [DataMember]
        public string GroupColor { get; set; }

    }

    //[Serializable]
    //[DataContract]
    public class PhotoSetModel
    {
        [DataMember]
        public List<PhotoModel> Photos { get; set; }

        [DataMember]
        public PagerPageModel Page { get; set; }
    }
    
}