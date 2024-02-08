using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Database.Models;

namespace RapidPay.Database
{
    public class SchedulerDbInitializer
    {
        private static RapidPayContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RapidPayContext>();
                InitializeSchedules(context);
            }
        }

        private static void InitializeSchedules(RapidPayContext context)
        {
            if (!context.User.Any())
            {
                User user_01 = new User {UserName = "User1", Password = "User1" };
                User user_02 = new User {UserName = "User2", Password = "User2" };
                User user_03 = new User {UserName = "User3", Password = "User3" };
                
                context.User.Add(user_01); 
                context.User.Add(user_02);
                context.User.Add(user_03); 

                context.SaveChanges();
            }

        }
    }
}
