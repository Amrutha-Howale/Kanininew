using EmployeeGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeGateway.Services
{
    public class EmployeeService
    {
        private readonly EmployeeContext _context;
        private readonly ITokenService _tokenService;
        public EmployeeService(EmployeeContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public EmployeeDTO Register(EmployeeDTO empDto)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var employee = new Employee()
                {
                    EmpId = empDto.Id,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(empDto.Password)),
                    PasswordSalt = hmac.Key
                };
                _context.employees.Add(employee);
                _context.SaveChanges();
                empDto.jwtToken = _tokenService.CreateToken(empDto);
                empDto.Password = "";
                return empDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public EmployeeDTO Login(EmployeeDTO empDto)
        {
            try
            {
                var myUser = _context.employees.SingleOrDefault(u => u.EmpId == empDto.Id);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(empDto.Password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    empDto.jwtToken = _tokenService.CreateToken(empDto);
                    empDto.Password = "";
                    return empDto;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
