using Abp.Application.Services;
using AutoMapper;
using SoiticTest.Models;
using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Providers
{
    public class ProviderAppService : ApplicationService,IProviderAppService
    {
        private readonly IProviderManager _providerManager;

        public ProviderAppService(IProviderManager providerManager)
        {
            _providerManager = providerManager;
        }

        public async Task Create(CreateProviderInput input)
        {
            Provider provider = Mapper.Map<CreateProviderInput, Provider>(input);
            await _providerManager.Create(provider);
        }

        public void Delete(DeleteProviderInput input)
        {
            _providerManager.Delete(input.Id);
        }

        public GetProviderOutput GetProviderById(GetProviderInput input)
        {
            var getProvider = _providerManager.GetProviderByID(input.Id);
            GetProviderOutput provider = Mapper.Map<Provider, GetProviderOutput>(getProvider);
            return provider;
        }

        public IEnumerable<GetProviderOutput> ListAll()
        {
            var getAll = _providerManager.GetAllList().ToList();
            List<GetProviderOutput> providers = Mapper.Map<List<Provider>, List<GetProviderOutput>>(getAll);
            return providers;
        }

        public void Update(UpdateProviderInput input)
        {
            Provider provider = Mapper.Map<UpdateProviderInput, Provider>(input);
            _providerManager.Update(provider);
        }
    }
}
