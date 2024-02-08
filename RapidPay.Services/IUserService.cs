using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public interface IUserService
    {
        bool UserVerify(string username, string password);
    }
}
