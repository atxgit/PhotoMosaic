using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoMosaic.Models
{

    [Serializable]
    public class PhotoTagModel
    {
        [Required]
        [Display(Name = "Photo Tag Identifier")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Photo Tag Type")]
        public string Type { get; set; }


        [Required]
        [Display(Name = "Photo Tag Name")]
        public string Name { get; set; }
    }

    [Serializable]
    public class PhotoTagSetModel
    {
        [Required]
        [Display(Name = "Photo Tag List")]
        public List<PhotoTagModel> PhotoTags { get; set; }

        public PagerPageModel Page { get; set; }

        public PhotoTagSetModel()
        {
            PhotoTags = new List<PhotoTagModel>();

        }
    }
}