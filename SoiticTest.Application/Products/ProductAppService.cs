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
                product.Providers.Add(Mapper.Map<ProviderDto, Provider>(provider));
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

        public void Update(ProductDto input)
        {
            Product product = Mapper.Map<ProductDto, Product>(input);
            _productManager.Update(product);
        }

        IEnumerable<ProviderDto> IProductAppService.GetProviders()
        {
            var getAll = _providerManager.GetAllList().ToList();
            List<ProviderDto> providers = Mapper.Map<List<Provider>, List<ProviderDto>>(getAll);
            return providers;
        }
    }
}
