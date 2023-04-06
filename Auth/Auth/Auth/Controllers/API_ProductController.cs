using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auth.Models;

namespace Auth.Controllers
{
    public class API_ProductController : ApiController
    {
        WEBCAPHE7Entities db = new WEBCAPHE7Entities();
        public IEnumerable<Product> GetAllProducts()
        {
            IList<Product> products = new List<Product>();
            var query = (from pros in db.douongs select pros).ToList();
            foreach (var p in query)
            {
                products.Add(new Product
                {
                    Madouong = p.Madouong,
                    Tendouong = p.Tendouong,
                    dongiaban = p.dongiaban,
                    Anh = p.Anh,
                    Mota = p.Mota,
                    MaLoai = p.Maloai
                });
            }
            return products;
        }

        public IEnumerable<Product> GetDetailsProduct(string MaLoai)
        {
            IList<Product> products = new List<Product>();
            var query = (from pros in db.douongs where pros.Maloai == MaLoai select pros).ToList();
            foreach (var p in query)
            {
                products.Add(new Product
                {
                    Madouong = p.Madouong,
                    Tendouong = p.Tendouong,
                    dongiaban = p.dongiaban,
                    Anh = p.Anh,
                    Mota = p.Mota,
                    MaLoai = p.Maloai
                });
            }
            return products;
        }
    }
}
