using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;


namespace WebApplication2.ViewModels
{
    public class orders_warehouses
    {
        public Order naracki { get; set; }
        public List<Warehouse> magacini { get; set; }
    }
}