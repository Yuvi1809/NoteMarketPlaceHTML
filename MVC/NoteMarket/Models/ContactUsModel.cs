using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteMarket.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "Please Enter the  Name")]
        public string FirstName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter the EmailAddress")]
        public string EmaiId { get; set; }
        [Required(ErrorMessage = "Please Enter Subject")]
        public string Subject { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter the Comment/Query")]
        public string comment { get; set; }
            
    }
}