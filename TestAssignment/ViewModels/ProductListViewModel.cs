using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Const;
using TestAssignment.Domain.Models.DomainModels;

namespace TestAssignment.ViewModels
{
    public class ProductListViewModel
    {
       
        public List<Product> Products { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; } 
    }
}