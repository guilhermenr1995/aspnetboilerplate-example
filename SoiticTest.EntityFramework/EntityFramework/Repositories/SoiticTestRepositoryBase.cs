using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace SoiticTest.EntityFramework.Repositories
{
    public abstract class SoiticTestRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SoiticTestDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SoiticTestRepositoryBase(IDbContextProvider<SoiticTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SoiticTestRepositoryBase<TEntity> : SoiticTestRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SoiticTestRepositoryBase(IDbContextProvider<SoiticTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
