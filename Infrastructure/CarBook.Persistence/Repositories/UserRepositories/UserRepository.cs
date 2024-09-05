using CarBook.Application.Interfaces.UserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarBookContext _context;

        public UserRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        {
            var values = await _context.Users.Where(filter).FirstOrDefaultAsync();
            return values;
        }
    }
}
