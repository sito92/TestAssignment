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
    [Authorize]
    public class ProductController : Controller
    {
        private const string ErrorMessage = "ErrorMessage";
        private const string Message = "Message";

        private readonly IProductRepository productRepository;
        private readonly ISuplierRepository suplierRepository;
        private readonly ICategoryRepository categoryRepository;
        public ProductController(IProductRepository _productRepository, ISuplierRepository _suplierRepository, ICategoryRepository _categoryRepository)
        {
            productRepository = _productRepository;
            suplierRepository = _suplierRepository;
            categoryRepository = _categoryRepository;
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
            var viewModel = GetDefaultProductViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductViewModel viewModel = GetDefaultProductViewModel();
                viewModel.Product = product;
                return View(viewModel);
            }

            productRepository.Add(product);
            productRepository.SaveChanges();

            TempData[Message] = Messages.ProductAddedSuccess;
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult EditAjax(int id)
        {

            return RedirectToAction("Edit", id);
        }
        public ActionResult Edit(int id)
        {
            var productToEdit = productRepository.GetProduct(id);
            if (productToEdit != null)
            {
                var viewModel = GetDefaultProductViewModel();
                viewModel.Product = productToEdit;
                return View(viewModel);
            }
            

            TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductViewModel viewModel = GetDefaultProductViewModel();
                viewModel.Product = product;
                return View(viewModel);
            }

            productRepository.Save(product);
            productRepository.SaveChanges();

            TempData[Message] = Messages.ProductEditedSuccess;
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var productToDelete = productRepository.GetProduct(id);
            if (productToDelete == null)
            {
                TempData[Message] = ErrorMessages.ProductNotFound;
                return RedirectToAction("List");
            }

            productRepository.Delete(productToDelete);
            productRepository.SaveChanges();
            TempData[Message] = Messages.ProductDeletedSuccess;

            return RedirectToAction("List");
        }

        public ActionResult DeleteMultiple(List<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                TempData[ErrorMessage] = ErrorMessages.ProductsNotFound;
                return RedirectToAction("List");
            }
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

        private ProductViewModel GetDefaultProductViewModel()
        {
            ProductViewModel viewModel = new ProductViewModel()
            {
                AvaibleCategories = new SelectList(categoryRepository.GetAll(), "Id", "Name"),
                AvaibleSupliers = new SelectList(suplierRepository.GetAll(), "Id", "Name")
            };
            return viewModel;
        }

    }
}