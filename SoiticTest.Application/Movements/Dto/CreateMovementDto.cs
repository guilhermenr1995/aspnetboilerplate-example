using Abp.AutoMapper;
using SoiticTest.Authorization.Users;
using SoiticTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Movements.Dto
{
    public class CreateMovementDto
    {
        public int Product { get; set; }
        public int Quantity { get; set; }
        public int PreviousQtd { get; set; }
        public int CurrentQtd { get; set; }
        public string Signal { get; set; }
    }
}
