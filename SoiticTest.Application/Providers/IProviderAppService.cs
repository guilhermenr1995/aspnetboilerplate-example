using Abp.Application.Services;
using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Providers
{
    public interface IProviderAppService : IApplicationService
    {
        IEnumerable<GetProviderOutput> ListAll();
        Task Create(CreateProviderInput input);
        void Update(UpdateProviderInput input);
        void Delete(DeleteProviderInput input);
        GetProviderOutput GetProviderById(GetProviderInput input);
    }
}
