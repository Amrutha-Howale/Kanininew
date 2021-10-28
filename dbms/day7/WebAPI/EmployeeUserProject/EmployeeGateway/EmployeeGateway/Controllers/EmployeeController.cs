using EmployeeGateway.Models;
using EmployeeGateway.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService employeeService)
        {
            _service = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return null;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post([FromBody] EmployeeDTO employee)
        {
            var employeeDTO = _service.Register(employee);
            if (employeeDTO != null)
                return employeeDTO;
            return BadRequest("Not able to register");
        }

        // PUT api/<EmployeeController>/5
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Put([FromBody] EmployeeDTO employee)
        {
            var employeeDTO = _service.Login(employee);
            if (employeeDTO != null)
                return Ok(employeeDTO);
            return BadRequest("Not able to register");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
