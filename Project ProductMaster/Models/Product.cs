using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ProductMaster.Models
{
    public class Product
    {


        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }


        [NotMapped]
        public int PageNumber { get; set; } = 1;
        [NotMapped]
        public int PageCount { get; set; } = 1;

        

    }
}