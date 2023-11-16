using Domain.Dto.Request;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace POS.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly ISaladOrderService _saladOrderService;
        private readonly IGrillOrderService _grillOrderService;
        private readonly IFriesOrderService _friesOrderService;
        private readonly IDrinkOrderService _drinkOrderService;

        public OrderController(IOrderService order,
            ISaladOrderService saladOrderService,
            IGrillOrderService grillOrderService,
            IFriesOrderService friesOrderService,
            IDrinkOrderService drinkOrderService)
        {
            _order = order;
            _saladOrderService = saladOrderService;
            _grillOrderService = grillOrderService;
            _friesOrderService = friesOrderService;
            _drinkOrderService = drinkOrderService;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _order.GetOrdersForId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
           
        }
        
        [HttpPost("/fries")]
        public IActionResult OrderFries([FromBody] OrderFriesDto order)
        {
            try
            {
                _friesOrderService.SendFriesOrder(order);
                return Ok("Order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("/grill")]
        public IActionResult OrderGrill([FromBody] GrillOrderDto order)
        {
            try
            {
                _grillOrderService.SendGrillOrder(order);
                return Ok("Order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("/salad")]
        public IActionResult OrderSalad([FromBody] SaladOrderDto order)
        {
            try
            {
                _saladOrderService.SendSaladOrder(order);
                return Ok("Order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("/drink")]
        public IActionResult OrderDrink([FromBody] DrinkOrderDto order)
        {
            try
            {
                _drinkOrderService.SendDrinkOrder(order);
                return Ok("Order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
