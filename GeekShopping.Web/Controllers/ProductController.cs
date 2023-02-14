﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers {
    public class ProductController : Controller {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex() {
            var products = await _productService.FindAllProducts();
            return View(products);
        }
        
        public async Task<IActionResult> ProductCreate() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model) {
            if (ModelState.IsValid) {
                var response = await _productService.CreateProduct(model);
                if(response != null) {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id) {
            var product = await _productService.FindProductById(id);
            if (product != null) {
                return View(product);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel product) {
            if (ModelState.IsValid) {
                var response = await _productService.UpdateProduct(product);
                if (response != null) {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductDelete(long id) {
            var product = await _productService.FindProductById(id);
            if (product != null) {
                return View(product);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel product) {
            var response = await _productService.DeleteProductById(product.Id);
            if (response) {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }
    }
}