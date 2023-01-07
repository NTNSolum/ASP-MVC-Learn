using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        private readonly ProductService _productServices;

        public FirstController(ILogger<FirstController> logger, ProductService productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }
        public IActionResult Index()
        {            
            return View();
        }

        // Model
        public IActionResult ViewProduct(int? id)
        {
            var product = _productServices.Where(p => p.ID == id).FirstOrDefault();
            if (product == null)
            {
                TempData["Thongbao"] = "Sản phẩm không tồn tại";
                return Redirect(Url.Action("Index", "Home"));
            }            

            return View(product);
        }

        //ViewData
        public IActionResult ViewProduct2(int? id)
        {
            var product = _productServices.Where(p => p.ID == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }            
            ViewData["product"] = product;
            ViewData["Title"] = product.Name;
            return View();
        }

        //ViewBag
        public IActionResult ViewProduct3(int? id)
        {
            var product = _productServices.Where(p => p.ID == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            
            ViewBag.product = product;
            return View();
        }
    }
}
