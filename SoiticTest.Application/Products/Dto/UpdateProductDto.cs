﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Products.Dto
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Value { get; set; }
        public int Stock { get; set; }
        public int[] ProviderIds { get; set; }
    }
}
