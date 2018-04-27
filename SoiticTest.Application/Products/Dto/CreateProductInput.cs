using SoiticTest.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products.DTO
{
    public class CreateProductInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Value { get; set; }
        public int Stock { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<CreateProviderInput> Providers { get; set; }
    }
}
