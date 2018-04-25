using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products.DTO
{
    public class UpdateProductInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Value { get; set; }
        public int Stock { get; set; }
    }
}
