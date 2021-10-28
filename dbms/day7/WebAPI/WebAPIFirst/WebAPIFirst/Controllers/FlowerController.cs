using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFirst.Models;
using WebAPIFirst.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class FlowerController : ControllerBase
    {
        private readonly FlowerService _service;

        public FlowerController(FlowerService flowerService)
        {
            _service = flowerService;
        }
        // POST api/<FlowerController>
        [HttpPost]
        public async Task<ActionResult<Flower>> Post([FromBody] Flower flower)
        {
            var flower1 = _service.Add(flower);
            if (flower1 != null)
                return flower1;
            return BadRequest("Not able to register");
        }


    }
}
