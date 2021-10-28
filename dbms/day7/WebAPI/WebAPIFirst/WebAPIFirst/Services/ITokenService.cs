using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFirst.Models;

namespace WebAPIFirst.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
        
    }
}
