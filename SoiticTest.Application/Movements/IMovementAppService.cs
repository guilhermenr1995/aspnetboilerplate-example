using Abp.Application.Services;
using SoiticTest.Models;
using SoiticTest.Movements.Dto;
using SoiticTest.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SoiticTest.Movements
{
    public interface IMovementAppService : IApplicationService
    {
        [HttpGet]
        IEnumerable<GetMovementDto> GetAll();

        [HttpPost]
        Task Create(CreateMovementDto input);

        [HttpPut]
        void Update(GetMovementDto input);

        [HttpPost]
        void Delete(GetMovementDto input);

        [HttpGet]
        GetMovementDto GetById(GetMovementDto input);

        IEnumerable<ProductDto> GetProducts();
    }
}
