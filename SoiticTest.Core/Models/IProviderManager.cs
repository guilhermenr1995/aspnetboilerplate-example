using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    public interface IProviderManager:IDomainService
    {
        IEnumerable<Provider> GetAllList();
        Provider GetProviderByID(int id);
        Task<Provider> Create(Provider entity);
        void Update(Provider entity);
        void Delete(int id);
    }
}
