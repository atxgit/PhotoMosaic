using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoMosaic.Models
{

    public class PagerPageModel
    {
        [Required]
        [Display(Name = "Page Size")]
        public int Size { get; set; }

        /// <summary>
        /// NOTE: First Page is Page One
        /// </summary>
        [Required]
        [Display(Name = "Page Index")]
        public int Index { get; set; }

        [Required]
        [Display(Name = "Total Page Count")]
        public int TotalPageCount { get; set; }

        public static int FIRST_PAGE_INDEX = 1;
    }




}