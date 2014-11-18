using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoMosaic.Models
{
    [Serializable]
    public class PhotoModel
    {
        [Required]
        [Display(Name = "Photo Identifier")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Photo URL")]
        public string Url { get; set; }

    }

    [Serializable]
    public class PhotoSetModel
    {
        [Required]
        [Display(Name = "Photo List")]
        public List<PhotoModel> Photos { get; set; }

        public PagerPageModel Page { get; set; }
    }
    
}