using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace NoteMarket.Models
{
    
    public class UserProfileModal
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public HttpPostedFileBase dp { get; set; }
        [DisplayName("Upload file")]
        public string uploaddp { get; set; }
        [DataType(DataType.Date)]
        public DateTime bdate {get;set;}
        public string phone { get; set; }
        [Required(ErrorMessage = "Please Enter the Address")]
        public string add1 { get; set; }
        [Required(ErrorMessage = "Please Enter the Address")]
        public string add2 { get; set; }
        [Required(ErrorMessage = "Please Enter the City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please Enter the Zipcode")]
        public string zipcode { get; set; }
        [Required(ErrorMessage = "Please Enter the State")]
        public string state { get; set; }
        [Required(ErrorMessage = "Please Enter the Country")]
        public string country { get; set; }
        public string university { get; set; }
        public string collage { get; set; }

        
    }

    

}