using Abp.Application.Services;
using SoiticTest.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products
{
    public interface IProductAppService:IApplicationService
    {
        IEnumerable<GetProductOutput> ListAll();
        Task Create(CreateProductInput input);
        void Update(UpdateProductInput input);
        void Delete(DeleteProductInput input);
        GetProductOutput GetProductById(GetProductInput input);
    }
}
