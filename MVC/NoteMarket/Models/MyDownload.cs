using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteMarket.Models
{
    public class MyDownload
    {
        public int id { get; set; }
        public string category { get; set; }
        public string emailid { get; set; }
        public bool sellfor { get; set; }
        public string sellprise { get; set; }
        public string title { get; set; }
        public bool isactive { get; set; }
        public string approvedate { get; set; }
        public string urnote { get; set; }
        public string comment { get; set; }
        public int rate { get; set; }
        public int buyid { get; set; }
        }
    }
