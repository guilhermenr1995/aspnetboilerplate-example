using Abp.Application.Services;
using AutoMapper;
using SoiticTest.Models;
using SoiticTest.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products
{
    public class ProductAppService:ApplicationService,IProductAppService
    {
        private readonly IProductManager _productManager;

        public ProductAppService(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task Create(CreateProductInput input)
        {
            Product product = Mapper.Map<CreateProductInput, Product>(input);
            await _productManager.Create(product);
        }

        public void Delete(DeleteProductInput input)
        {
            _productManager.Delete(input.Id);
        }

        public GetProductOutput GetById(GetProductInput input)
        {
            var getProduct = _productManager.GetProductByID(input.Id);
            GetProductOutput product = Mapper.Map<Product, GetProductOutput>(getProduct);
            return product;
        }

        public IEnumerable<GetProductOutput> GetAll()
        {
            var getAll = _productManager.GetAllList().ToList();
            List<GetProductOutput> products = Mapper.Map<List <Product>, List <GetProductOutput>>(getAll);
            return products;
        }

        public void Update(UpdateProductInput input)
        {
            Product product = Mapper.Map<UpdateProductInput, Product>(input);
            _productManager.Update(product);
        }
    }
}
