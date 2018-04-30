using SoiticTest.Authorization.Users;
using SoiticTest.Models;
using SoiticTest.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Movements.Dto
{
    public class MovementDto
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int PreviousQtd { get; set; }
        public int CurrentQtd { get; set; }
        public string Signal { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
