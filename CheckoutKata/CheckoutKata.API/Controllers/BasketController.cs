using System;
using System.Net;
using System.Threading.Tasks;
using CheckoutKata.Business.Interfaces;
using CheckoutKata.Common.Exceptions;
using CheckoutKata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CheckoutKata.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketManager _basketManager;
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger, IBasketManager basketManager)
        {
            _logger = logger;
            _basketManager = basketManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddToBasketModel model)
        {
            try
            {
                await _basketManager.AddItemToBasket(model.SKU);

                return Ok();
            }
            catch (ProductNotFoundException ex)
            {
                _logger.LogInformation(ex, "Error occured added item to basket");
                return BadRequest("Product code not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured added item to basket");
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentBasket()
        {
            try
            {
                var basketModel = await _basketManager.GetCurrentBasket();

                return Ok(basketModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured retrieving basket");
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }
    }
}