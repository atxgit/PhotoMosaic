using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PhotoMosaic.Models
{

    public class PagerPageModel
    {
        [DataMember]
        public int Size { get; set; }

        /// <summary>
        /// NOTE: First Page is Page One
        /// </summary>
        [DataMember]
        public int Index { get; set; }

        [DataMember]
        public int TotalPageCount { get; set; }

        public static int FIRST_PAGE_INDEX = 1;
    }




}