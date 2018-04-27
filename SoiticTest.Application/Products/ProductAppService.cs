using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SoiticTest.Models;
using SoiticTest.Products.DTO;
using SoiticTest.Providers;
using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products
{
    public class ProductAppService:ApplicationService, IProductAppService
    {
        private readonly IProductManager _productManager;
        private readonly IRepository<Provider> _providerRepository;
        private readonly ProviderManager _providerManager;

        public ProductAppService(
            IProductManager productManager,
            IRepository<Provider> providerRepository,
            ProviderManager providerManager
            )  
        {
            _productManager = productManager;
            _providerRepository = providerRepository;
            _providerManager = providerManager;
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

        public IEnumerable<GetProviderOutput> GetProviders()
        {
            var getAll = _providerManager.GetAllList().ToList();
            List<GetProviderOutput> providers = Mapper.Map<List<Provider>, List<GetProviderOutput>>(getAll);
            return providers;
        }
    }
}
