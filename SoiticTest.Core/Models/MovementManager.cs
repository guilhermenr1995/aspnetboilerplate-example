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
    public class MovementManager : DomainService, IMovementManager
    {
        private readonly IRepository<Movement> _repositoryMovement;

        public MovementManager(IRepository<Movement> repositoryMovement)
        {
            _repositoryMovement = repositoryMovement;
        }

        public async Task<Movement> Create(Movement entity)
        {
            var movement = _repositoryMovement.FirstOrDefault(x => x.Id == entity.Id);
            if (movement != null)
            {
                throw new UserFriendlyException("Item já existente!");
            }
            else
            {
                return await _repositoryMovement.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var movement = _repositoryMovement.FirstOrDefault(x => x.Id == id);

            if (movement == null)
            {
                throw new UserFriendlyException("Produto não encontrado!");
            }
            else
            {
                _repositoryMovement.Delete(movement);
            }
        }

        public virtual IEnumerable<Movement> GetAllList()
        {
            return _repositoryMovement.GetAll();
        }

        public Movement GetMovementByID(int id)
        {
            return _repositoryMovement.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movement entity)
        {
            _repositoryMovement.Update(entity);
        }
    }
}
