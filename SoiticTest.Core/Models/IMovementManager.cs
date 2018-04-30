using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    public interface IMovementManager : IDomainService
    {
        IEnumerable<Movement> GetAllList();
        Movement GetMovementByID(int id);
        Task<Movement> Create(Movement entity);
        void Update(Movement entity);
        void Delete(int id);
    }
}
