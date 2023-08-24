using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersMicroService.Model
{
    public class ProductsModelDTO
    {

        [Required]
        [Key]
        public string productid { get; set; }
        public string productname { get; set; }
        public int productqty { get; set; }

        public string orderid { get; set; }
    }
}
