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
        IEnumerable<ProviderDto> GetAll();

        [HttpPost]
        Task Create(ProviderDto input);

        [HttpPut]
        void Update(ProviderDto input);

        [HttpPost]
        void Delete(ProviderDto input);

        [HttpGet]
        ProviderDto GetById(ProviderDto input);
    }
}
