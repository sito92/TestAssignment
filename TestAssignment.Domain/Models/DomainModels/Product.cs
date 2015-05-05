using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment.Domain.Models.DomainModels
{
    public class Product:Entity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int DeliverPeriod { get; set; }
        public int SuplierId { get; set; }
        public int CategoryId { get; set; }
        public string MinStock { get; set; }


        public virtual Suplier Suplier { get; set; } 
        public virtual Category Category { get; set; }

    }
}
