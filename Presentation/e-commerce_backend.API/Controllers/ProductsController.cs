﻿using e_commerce_backend.Application.Repositories;
using e_commerce_backend.Application.RequestParameters;
using e_commerce_backend.Application.Services;
using e_commerce_backend.Application.ViewModels.Products;
using e_commerce_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace e_commerce_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IFileService _fileService;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();

            return Ok(new
            {
                totalCount,
                products
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            return Ok();
        }

    }
}
