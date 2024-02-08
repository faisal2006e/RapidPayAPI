using RapidPay.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public interface ICardsService
    {
        Task<bool> CreateCard(CardsDto cardsDTO);
        Task<bool> Pay(CardsDto cardsDTO);
        Task<decimal> GetCardBalance(CardsDto cardsDTO);
    }
}
