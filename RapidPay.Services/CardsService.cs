using RapidPay.Database;
using RapidPay.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidPay.Database.Models;

namespace RapidPay.Services
{
    public class CardsService : ICardsService
    {
        private RapidPayContext _context;
        private readonly UfeService _ufeService = UfeService.Instance;
        public CardsService(RapidPayContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCard(CardsDto cardsDTO) 
        {
            bool result = false;

            Cards cards = new Cards();
            cards.CardNumber = cardsDTO.CardNumber;
            cards.CardBalance = cardsDTO.CardBalance;
            cards.CreatedDate = DateTime.Now;

            _context.Cards.Add(cards);
            _context.SaveChanges();
            result = true;
            return  result;
        }

        public async Task<bool> Pay(int cardNumber)
        {
            bool result = false;
            decimal fee = _ufeService.GetFee();
            Cards cards = await GetCard(cardNumber);
            decimal totalAmount = cards.CardBalance + fee;
            cards.CardBalance = totalAmount;

            cards.LastBalanceUpdateDate = DateTime.Now;
           
            _context.Cards.Update(cards);
            _context.SaveChanges();
            result = true;
            return result;
        }

        public async Task<decimal> GetCardBalance(int cardNumber)
        {
            var card = await GetCard(cardNumber);
            return card.CardBalance;
        }

        public async Task<Cards> GetCard(int cardNumber)
        {
            return _context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
        }
    }
}
