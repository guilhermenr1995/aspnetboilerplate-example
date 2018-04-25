using Abp.Application.Services;
using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SoiticTest.Providers
{
    public interface IProviderAppService : IApplicationService
    {
        [HttpGet]
        IEnumerable<GetProviderOutput> GetAll();

        [HttpPost]
        Task Create(CreateProviderInput input);

        [HttpPut]
        void Update(UpdateProviderInput input);

        [HttpDelete]
        void Delete(DeleteProviderInput input);

        [HttpGet]
        GetProviderOutput GetById(GetProviderInput input);
    }
}
