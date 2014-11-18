using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoMosaic.Models
{
    public class AuthCredentialsModel
    {
        [Required]
        [Display(Name = "User EMail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Public Token")]
        public string Token { get; set; }
    }


}