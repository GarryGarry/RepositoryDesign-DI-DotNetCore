using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.BusinessObjects;
using MyProject.Context;
using MyProject.Respository;

namespace MyProject.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Sale> _saleRepository;

        public HomeController(
             IRepository<Customer> CustomerRepository,
            IRepository<Product> ProductRepository,
            IRepository<Sale> SaleRepository
            )
        {
            _customerRepository = CustomerRepository;
            _productRepository = ProductRepository;
            _saleRepository = SaleRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult CustomerList()
        {
            var model = _customerRepository.GetAll().ToList();
            return Json(model);
        }
    }
}