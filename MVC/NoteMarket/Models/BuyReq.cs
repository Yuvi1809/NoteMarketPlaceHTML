using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteMarket.Models
{
    public class BuyReq
    {
       
        public string title { get; set; }
        public string course { get; set; }
        public string emailid { get; set; }
        public string phoneno { get; set; }
        public bool sellfor { get; set; }
        public string sellprice { get; set; }
        public DateTime reqdate { get; set; }
        public string aprov { get; set; }
        public bool isactive { get; set; }
        public int id { get; set; }
       
    }
}