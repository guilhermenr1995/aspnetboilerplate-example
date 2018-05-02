using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SoiticTest.Models;
using SoiticTest.Products.Dto;
using SoiticTest.Providers;
using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;

namespace SoiticTest.Products
{
    public class ProductAppService:ApplicationService, IProductAppService
    {
        private readonly IProductManager _productManager;
        private readonly IRepository<Provider> _providerRepository;
        private readonly ProviderManager _providerManager;

        public new ILogger Logger { get; set; }

        public ProductAppService(
            IProductManager productManager,
            IRepository<Provider> providerRepository,
            ProviderManager providerManager
            )  
        {
            _productManager = productManager;
            _providerRepository = providerRepository;
            _providerManager = providerManager;

            Logger = NullLogger.Instance;
        }

        public async Task Create(ProductDto input)
        {
            var product = ObjectMapper.Map<Product>(input);

            product.Providers = new Collection<Provider>();

            foreach (var provider in input.Providers)
            {
                var providerFound = _providerManager.GetProviderByID(provider.Id);
                product.Providers.Add(providerFound);
            }

            await _productManager.Create(product);
        }

        public void Delete(ProductDto input)
        {
            _productManager.Delete(input.Id);
        }

        public ProductDto GetById(ProductDto input)
        {
            var getProduct = _productManager.GetProductByID(input.Id);
            ProductDto product = Mapper.Map<Product, ProductDto>(getProduct);
            return product;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var getAll = _productManager.GetAllList().ToList();
            List<ProductDto> products = Mapper.Map<List<Product>, List<ProductDto>>(getAll);
            return products;
        }

        public void Update(UpdateProductDto input)
        {   
            // Remover primeiro as existentes
            var productDb = _productManager.GetProductByID(input.Id);

            foreach (var provider in productDb.Providers.ToList())
            {
                productDb.Providers.Remove(provider);
            }

            foreach (var providerId in input.ProviderIds)
            {
                var providerDb = _providerManager.GetProviderByID(providerId);
                productDb.Providers.Add(providerDb);
            }

            /*
            public string Name { get; set; }
            public string Description { get; set; }
            public string Brand { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public decimal Value { get; set; }
            public int Stock { get; set; } */

            productDb.Name = input.Name;
            productDb.Description = input.Description;
            productDb.Brand = input.Brand;
            productDb.EntryDate = input.EntryDate;
            productDb.ExpirationDate = input.ExpirationDate;
            productDb.Value = input.Value;
            productDb.Stock = input.Stock;

            _productManager.Update(productDb);
        }

        IEnumerable<ProviderDto> IProductAppService.GetProviders()
        {
            var getAll = _providerManager.GetAllList().ToList();
            List<ProviderDto> providers = Mapper.Map<List<Provider>, List<ProviderDto>>(getAll);
            return providers;
        }
    }
}
