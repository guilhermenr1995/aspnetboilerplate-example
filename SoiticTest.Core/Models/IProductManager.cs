using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    public interface IProductManager:IDomainService
    {
        IEnumerable<Product> GetAllList();
        Product GetProductByID(int id);
        Task<Product> Create(Product entity);
        void Update(Product entity);
        void Delete(int id);
    }
}
