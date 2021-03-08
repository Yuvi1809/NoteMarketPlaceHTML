using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace NoteMarket.Models
{
    public class AddNotesModel
    {
        
        public string Title { get; set; }
         [DataType(DataType.Text)]
        public string Noofpage { get; set; }
        public string Disc { get; set; }
        public string instituename { get; set; }
        public string coursename { get; set; }
        public string coursecode { get; set; }
        public string professor { get; set; }
        public string price { get; set; }
        [DisplayName("Upload file")]
        public string dppath{ get; set; }
        public HttpPostedFileBase dp { get; set; }
        [DisplayName("Upload file")]
        public string uploadpath { get; set; }
        public HttpPostedFileBase uploadnote { get; set; }
        [DisplayName("Upload file")]
        public string notepath { get; set; }
        public HttpPostedFileBase notepreview { get; set; }
        public string sellfor { get; set; }
        public string country { get; set; }
        public string category { get; set; }
        public string type { get; set; }
    }
}