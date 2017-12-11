using FormAuthSample4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormAuthSample4.ViewModel
{
    public class AccountViewModel
    {

        public User accountViewModel
        {
            get; set;
        }
        [Display(Name ="Remember Me?")]
       public bool rememberMe { get; set; }
    }
}