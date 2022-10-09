using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DB_Lib.Models
{
    public class Book
    {
        public int Bookid { get; set; }
        public string BookName { get; set; }
        public int cost { get; set; }
        public string Author { get; set; }
        public int memberid { get; set; }
    }
}