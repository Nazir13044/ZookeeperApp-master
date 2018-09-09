using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZookeeperApp.Models
{
    public class AnimalFood
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }

    }
}