using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Providers.Dto
{
    public class CreateProviderInput
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
    }
}
