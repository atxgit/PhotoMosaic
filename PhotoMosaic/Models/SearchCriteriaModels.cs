using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoMosaic.Models
{
    public class SearchCriteriaModel
    {
        [Required]
        [Display(Name = "Search String")]
        public string SearchString { get; set; }

        [Required]
        [Display(Name = "Search Type")]
        public string Type { get; set; }
        
    }


}