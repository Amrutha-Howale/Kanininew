﻿using EmployeeGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGateway.Services
{
    public interface ITokenService
    {
        public string CreateToken(EmployeeDTO employeeDTO);
    }
}
