using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class Product
    {
        public string Madouong { get; set; }
        public string Tendouong { get; set; }
        public string Mota { get; set; }

        public Nullable<double> dongiaban { get; set; }
        public string Anh { get; set; }
        public string Trongluong { get; set; }
        public string MaLoai { get; set; }
    }
}