using Abp.Application.Services;
using SoiticTest.Products.Dto;
using SoiticTest.Providers.Dto;
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
        IEnumerable<ProductDto> GetAll();

        [HttpPost]
        Task Create(ProductDto input);

        [HttpPut]
        void Update(UpdateProductDto input);

        [HttpPost]
        void Delete(ProductDto input);

        [HttpGet]
        ProductDto GetById(ProductDto input);

        IEnumerable<ProviderDto> GetProviders();
    }
}
