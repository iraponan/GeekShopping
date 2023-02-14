﻿using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll() {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id) {
            var product = await _repository.FindById(id);
            if (product.Id <= 0) {
                return NotFound();
            }
            else {
                return Ok(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO) {
            if (productVO == null) {
                return BadRequest();
            }
            else {
                var product = await _repository.Create(productVO);
                return Ok(product);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO productVO) {
            if (productVO == null) {
                return BadRequest();
            }
            else {
                var product = await _repository.Update(productVO);
                return Ok(product);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id) {
            var status = await _repository.Delete(id);
            if (!status) {
                return BadRequest();
            }
            else {
                return Ok(status);
            }
        }
    }
}
