
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteMarket.Models
{
    public class ChangePassModel
    {
        [DisplayName("Old Password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter the Oldpassword")]
        public String OldPassword{ get; set;}
        [DisplayName("New Password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter the Newdpassword")]
        public String NewPassword { get; set; }
        [DisplayName("Confirm Password*")]
        [DataType(DataType.Password)]
        [Compare ("NewPassword",ErrorMessage ="New Password Miss Match")]
        [Required(ErrorMessage = "Password miss match with new password")]
        public String CPassword { get; set; }
    }
}