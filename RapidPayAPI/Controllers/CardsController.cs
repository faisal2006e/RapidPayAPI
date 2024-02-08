using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Models.Dtos;
using RapidPay.Services;

namespace RapidPay.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private IConfiguration _config;
        private ICardsService _cardsService;
        public CardsController(IConfiguration config, ICardsService cardsService)
        {
            _config = config;
            _cardsService = cardsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CardsDto cardsDto)
        {
           return Ok(await _cardsService.CreateCard(cardsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Pay(CardsDto cardsDto)
        {
            return Ok(await _cardsService.CreateCard(cardsDto));
        }

        // Pay endpoint
        //public void Pay(string cardNumber, decimal amount)
        //{
        //    if (_cards.TryGetValue(cardNumber, out var card))
        //    {
        //        decimal fee = _ufeService.GetFee();
        //        decimal totalAmount = amount + fee;
        //        if (card.Balance >= totalAmount)
        //        {
        //            card.Balance -= totalAmount;
        //            Console.WriteLine($"Payment successful. Amount: {amount}, Fee: {fee}, Card Balance: {card.Balance}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Insufficient funds.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Card not found.");
        //    }
        //}

        // Get card balance endpoint
        //public decimal GetCardBalance(string cardNumber)
        //{
        //    if (_cards.TryGetValue(cardNumber, out var card))
        //    {
        //        return card.Balance;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Card not found.");
        //        return 0.0m;
        //    }
        //}
    }
}
