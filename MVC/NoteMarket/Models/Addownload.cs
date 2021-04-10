using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteMarket.Models
{
    public class Addownload
    {
        public string category { get; set; }
        public string title { get; set; }
        public string buyer { get; set; }
        public string seller { get; set; }
        public bool selltype { get; set; }
        public string sellprice { get; set; }
        public DateTime downloadate { get; set; }
    }
}