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

        public async Task Create(ProviderDto input)
        {
            Provider provider = Mapper.Map<ProviderDto, Provider>(input);
            await _providerManager.Create(provider);
        }

        public void Delete(ProviderDto input)
        {
            _providerManager.Delete(input.Id);
        }

        public ProviderDto GetById(ProviderDto input)
        {
            var getProvider = _providerManager.GetProviderByID(input.Id);
            ProviderDto provider = Mapper.Map<Provider, ProviderDto>(getProvider);
            return provider;
        }

        public IEnumerable<ProviderDto> GetAll()
        {
            var getAll = _providerManager.GetAllList().ToList();
            List<ProviderDto> providers = Mapper.Map<List<Provider>, List<ProviderDto>>(getAll);
            return providers;
        }

        public void Update(ProviderDto input)
        {
            Provider provider = Mapper.Map<ProviderDto, Provider>(input);
            _providerManager.Update(provider);
        }
    }
}
