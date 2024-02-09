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

        [HttpPut]
        public async Task<IActionResult> Pay(int cardNumber)
        {
            return Ok(await _cardsService.Pay(cardNumber));
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance(int cardNumber)
        {
            return Ok(await _cardsService.GetCardBalance(cardNumber));
        }
    }
}
