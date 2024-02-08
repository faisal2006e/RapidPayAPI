using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Database.Models
{
    public class Cards
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public decimal CardBalance { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastBalanceUpdateDate { get; set; }
    }
}
