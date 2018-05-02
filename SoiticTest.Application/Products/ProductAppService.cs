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
using SoiticTest.Authorization.Users;

namespace SoiticTest.Products
{
    public class ProductAppService:ApplicationService, IProductAppService
    {
        private readonly IProductManager _productManager;
        private readonly IRepository<Provider> _providerRepository;
        private readonly ProviderManager _providerManager;
        private readonly IRepository<Movement> _movementRepository;
        private readonly MovementManager _movementManager;
        private readonly UserManager _userManager;


        public new ILogger Logger { get; set; }

        public ProductAppService(
            IProductManager productManager,
            IRepository<Provider> providerRepository,
            ProviderManager providerManager,
            IRepository<Movement> movementRepository,
            MovementManager movementManager,
            UserManager userManager
            )  
        {
            _productManager = productManager;
            _providerRepository = providerRepository;
            _providerManager = providerManager;
            _movementRepository = movementRepository;
            _movementManager = movementManager;
            _userManager = userManager;

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

        public async Task UpdateAsync(UpdateProductDto input)
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

            // Se o estoque mudou, cria uma movimentação
            if (productDb.Stock != input.Stock)
            {
                var userId = 1;

                if (AbpSession.UserId != null)
                {
                    userId = unchecked((int)AbpSession.UserId);
                }

                User user = await _userManager.FindByIdAsync(userId);

                var movement = new Movement();
                movement.Product = productDb;
                movement.User = user;
                movement.PreviousQtd = productDb.Stock;
                movement.CurrentQtd = input.Stock;

                // Se o estoque aumentou, cria uma movimentação positiva
                if (productDb.Stock > input.Stock)
                {
                    movement.Signal = "-";
                }
                else
                {
                    movement.Signal = "+";
                }

                await _movementManager.Create(movement);
            }

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
