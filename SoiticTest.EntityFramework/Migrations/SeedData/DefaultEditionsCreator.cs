using System.Linq;
using Abp.Application.Editions;
using SoiticTest.Editions;
using SoiticTest.EntityFramework;

namespace SoiticTest.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly SoiticTestDbContext _context;

        public DefaultEditionsCreator(SoiticTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}