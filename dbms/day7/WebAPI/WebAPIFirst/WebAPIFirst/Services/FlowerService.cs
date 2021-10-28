using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPIFirst.Models;

namespace WebAPIFirst.Services
{
    public class FlowerService
    {
        private readonly CompanyContext _context;
       
        public FlowerService(CompanyContext context)
        {
            _context = context;  
        }

        public Flower Add(Flower flower)
        {
            
            _context.flowers.Add(flower);
            _context.SaveChanges();
            return flower;
        }
    }
}
