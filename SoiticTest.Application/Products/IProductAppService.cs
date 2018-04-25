using Abp.Application.Services;
using SoiticTest.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SoiticTest.Products
{
    public interface IProductAppService:IApplicationService
    {
        [HttpGet]
        IEnumerable<GetProductOutput> GetAll();

        [HttpPost]
        Task Create(CreateProductInput input);

        [HttpPut]
        void Update(UpdateProductInput input);

        [HttpDelete]
        void Delete(DeleteProductInput input);

        [HttpGet]
        GetProductOutput GetById(GetProductInput input);
    }
}
