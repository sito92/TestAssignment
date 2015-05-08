using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAssignment.Domain.Models.DomainModels;

namespace TestAssignment.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Product = new Product();
        }
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> AvaibleCategories { get; set; }
        public IEnumerable<SelectListItem> AvaibleSupliers { get; set; }
    }
}