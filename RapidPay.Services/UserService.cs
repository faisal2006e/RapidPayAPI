using RapidPay.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class UserService : IUserService
    {
        private RapidPayContext _context;
        public UserService(RapidPayContext context)
        {
            _context = context;
        }
        public bool UserVerify(string username, string password) 
        {
            return _context.User.Any(x=> x.UserName == username && x.Password == password);
        }
    }
}
