using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class UfeService
    {
        private static UfeService _instance;
        private static readonly object _lock = new object();
        private decimal _lastFeeAmount = 1.0m;
        private Random _random = new Random();

        private UfeService() { }

        public static UfeService Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new UfeService();
                }
            }
        }

        public decimal GetFee()
        {
            // Simulate UFE selecting a random decimal between 0 and 2
            decimal randomDecimal = _random.Next(0, 200) / 100.0m;
            _lastFeeAmount *= randomDecimal;
            return _lastFeeAmount;
        }
    }
}
