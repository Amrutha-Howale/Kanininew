using LoginMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Services
{
    public class UserRepo : IRepo<User>
    {
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        {
            _context = context;
        }
        public User Add(User k)
        {
            try
            {
                _context.users.Add(k);
                _context.SaveChanges();
                return k;
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            IList<User> users = _context.users.ToList();
            if (users.Count > 0)
                return users;
            else
                return null;
        }

        public User Update(User k)
        {
            throw new NotImplementedException();
        }
    }
}
