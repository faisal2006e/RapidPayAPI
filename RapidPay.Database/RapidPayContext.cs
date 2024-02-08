using Microsoft.EntityFrameworkCore;
using RapidPay.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Database
{
    public class RapidPayContext : DbContext
    {
        public RapidPayContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Cards> Cards { get; set; }
    }
}
