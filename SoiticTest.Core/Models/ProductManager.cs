using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    public class ProductManager:DomainService, IProductManager
    {
        private readonly IRepository<Product> _repositoryProduct;

        public ProductManager(IRepository<Product> repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public async Task<Product> Create(Product entity)
        {
            var product = _repositoryProduct.FirstOrDefault(x => x.Id == entity.Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                return await _repositoryProduct.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var product = _repositoryProduct.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new UserFriendlyException("Produto não encontrado!");
            }
            else
            {
                _repositoryProduct.Delete(product);
            }
        }

        public IEnumerable<Product> GetAllList()
        {
            return _repositoryProduct.GetAllIncluding(x => x.Providers);
        }

        public Product GetProductByID(int id)
        {
            return _repositoryProduct.Get(id);
        }

        public void Update(Product entity)
        {
            _repositoryProduct.Update(entity);
        }
    }
}
