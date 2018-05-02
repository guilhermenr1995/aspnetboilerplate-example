using SoiticTest.Models;
using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string EntryDate { get; set; }
        public string ExpirationDate { get; set; }
        public decimal Value { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<ProviderDto> Providers { get; set; }
    }
}
