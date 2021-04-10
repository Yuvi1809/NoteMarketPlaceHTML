using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteMarket.Models
{
    public class MySold
    {
        public string title { get; set;}
        public string emailid { get; set;}
        public string course { get; set;}
        public string phoneno { get; set;}
        public bool sellfor { get; set;}
        public string sellprice { get; set;}
        public DateTime approved { get; set;}
        public bool isactive { get; set; }
    }
}