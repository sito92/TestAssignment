using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment.Domain.Models.DomainModels
{
    public class Product:Entity
    {
        [Required(ErrorMessage = "Product name is required")]
        [DisplayName("Product name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price name is required")]
        [DisplayName("Price")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Deliver period must be grater than 0")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Price name is required")]
        [DisplayName("Deliver period")]
        [Range(1, int.MaxValue,ErrorMessage = "Deliver period must be grater or equal to 1")]
        public int DeliverPeriod { get; set; }
        public int SuplierId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Minimum stock name is required")]
        [DisplayName("Minimum stock")]
        public string MinStock { get; set; }


        public virtual Suplier Suplier { get; set; } 
        public virtual Category Category { get; set; }

    }
}
