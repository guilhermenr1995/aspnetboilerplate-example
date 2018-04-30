using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    public class ProviderManager:DomainService, IProviderManager
    {
        private readonly IRepository<Provider> _repositoryProvider;

        public ProviderManager(IRepository<Provider> repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        public async Task<Provider> Create(Provider entity)
        {
            var provider = _repositoryProvider.FirstOrDefault(x => x.Id == entity.Id);
            if (provider != null)
            {
                throw new UserFriendlyException("Item já existente!");
            }
            else
            {
                return await _repositoryProvider.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var provider = _repositoryProvider.FirstOrDefault(x => x.Id == id);

            if (provider == null)
            {
                throw new UserFriendlyException("Produto não encontrado!");
            }
            else
            {
                _repositoryProvider.Delete(provider);
            }
        }

        public IEnumerable<Provider> GetAllList()
        {
            return _repositoryProvider.GetAllIncluding(x => x.Products);
        }

        public Provider GetProviderByID(int id)
        {
            return _repositoryProvider.FirstOrDefault(x => x.Id == id);
        }

        public Provider GetProviderByName(string name)
        {
            return _repositoryProvider.FirstOrDefault(x => x.Name == name);
        }

        public void Update(Provider entity)
        {
            _repositoryProvider.Update(entity);
        }
    }
}
