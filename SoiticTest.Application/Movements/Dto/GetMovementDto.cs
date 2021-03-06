﻿using SoiticTest.Authorization.Users;
using SoiticTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Movements.Dto
{
    public class GetMovementDto
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string User { get; set; }
        public int PreviousQtd { get; set; }
        public int CurrentQtd { get; set; }
        public string Signal { get; set; }
    }
}
