using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAssignment.Const;
using TestAssignment.Domain.Models.DomainModels;
using TestAssignment.Domain.Repository.Interfaces;
using TestAssignment.ViewModels;

namespace TestAssignment.Controllers
{
    public class ProductController : Controller
    {
        private const string ErrorMessage = "ErrorMessage";
        private const string Message = "Message";
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        // GET: Prouct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {

            ProductListViewModel viewModel = new ProductListViewModel()
            {
                Products = productRepository.GetAll().ToList()
            };

            UpdateMessages(viewModel);

            return View(viewModel);
        }

        private void UpdateMessages(ProductListViewModel viewModel)
        {
            if (TempData[Message] != null)
            {
                viewModel.Message = (string) TempData[Message];
            }
            if (TempData[ErrorMessage] != null)
            {
                viewModel.ErrorMessage = (string) TempData[ErrorMessage];
            }
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            productRepository.Add(product);
            productRepository.SaveChanges();

            TempData[Message] = Messages.ProductAddedSuccess;
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var productToEdit = productRepository.GetProduct(id);
            if (productToEdit != null) return View(productToEdit);

            TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            productRepository.Save(product);
            productRepository.SaveChanges();

            TempData[Message] = Messages.ProductEditedSuccess;
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var productToDelete = productRepository.GetProduct(id);
            if (productToDelete == null) return RedirectToAction("List");

            productRepository.Delete(productToDelete);
            productRepository.SaveChanges();
            TempData[Message] = Messages.ProductDeletedSuccess;

            return RedirectToAction("List");
        }

        public ActionResult DeleteMultiple(List<int> ids)
        {
            var productsToDelete = productRepository.FindBy(x => ids.Contains(x.Id));
            if (productsToDelete == null || !productsToDelete.Any())
            {
                TempData[ErrorMessage] = ErrorMessages.ProductsNotFound;
                return RedirectToAction("List");
            }


            foreach (var product in productsToDelete)
            {
                productRepository.Delete(product);
            }
            productRepository.SaveChanges();

            TempData[Message] = Messages.ProductsDeletedSuccess;
            return RedirectToAction("List");
        }


    }
}