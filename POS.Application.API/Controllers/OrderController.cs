using Domain.Dto.Request;
using Domain.Dto.Response;
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

        /// <summary>
        /// Retrieves orders associated with a specific identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>A list of orders associated with the provided identifier.</returns>
        /// <response code="200">Returns the list of orders successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDataReponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
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

        /// <summary>
        /// Places an order for French fries.
        /// </summary>
        /// <remarks>
        /// Request body example:
        ///
        ///     POST /fries
        ///     {
        ///       "idOrder": 1,
        ///       "specialInstructions": "None",
        ///       "orderType": "Fries",
        ///       "size": { Small = 1, Medium = 2, Large = 3 },
        ///       "sauce": { Ketchup = 1, Mayonnaise = 2, Barbecue = 3, Garlic = 4 },
        ///       "quantity": 1
        ///     }
        /// </remarks>
        /// <param name="order">Details of the French fries order.</param>
        /// <returns>Message indicating the success of the French fries order.</returns>
        /// <response code="200">French fries order received successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("/fries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult OrderFries([FromBody] OrderFriesDto order)
        {
            try
            {
                _friesOrderService.SendFriesOrder(order);
                return Ok("Fries order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Places an order for grilled items.
        /// </summary>
        /// <remarks>
        /// Request body example:
        ///
        ///     POST /grill
        ///     {
        ///       "idOrder": 1,
        ///       "specialInstructions": "None",
        ///       "orderType": "Grill",
        ///       "meat": { Beef = 1, Chicken = 2, Pork = 3, Fish = 4 },
        ///       "cookingPreference": { Rare = 1, MediumRare = 2, Medium = 3, MediumWell = 4, WellDone = 5 },
        ///       "sideDishes": true,
        ///       "quantity": 1
        ///     }
        ///     
        /// </remarks>
        /// <param name="order">Details of the grill order.</param>
        /// <returns>Message indicating the success of the grill order.</returns>
        /// <response code="200">Grill order received successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("/grill")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult OrderGrill([FromBody] GrillOrderDto order)
        {
            try
            {
                _grillOrderService.SendGrillOrder(order);
                return Ok("Grill order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Places an order for salad.
        /// </summary>
        /// <remarks>
        /// Request body example:
        ///
        ///     POST /salad
        ///     {
        ///       "idOrder": 1,
        ///       "specialInstructions": "None",
        ///       "orderType": "Salad",
        ///       "type": { Caesar = 1, Garden = 2, Caprese = 3, Greek = 4 },
        ///       "dressing": { Ranch = 1, Caesar = 2, Balsamic = 3, HoneyMustard = 4 },
        ///       "hasProtein": true,
        ///       "quantity": 1
        ///     }
        /// </remarks>
        /// <param name="order">Details of the salad order.</param>
        /// <returns>Message indicating the success of the salad order.</returns>
        /// <response code="200">Salad order received successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("/salad")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult OrderSalad([FromBody] SaladOrderDto order)
        {
            try
            {
                _saladOrderService.SendSaladOrder(order);
                return Ok("Salad order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Places an order for a drink.
        /// </summary>
        /// <remarks>
        /// Request body example:
        ///
        ///     POST /drink
        ///     {
        ///       "idOrder": 1,
        ///       "specialInstructions": "None",
        ///       "orderType": "Drink",
        ///       "type": { Soda = 1, IcedTea = 2, Lemonade = 3, Coffee = 4 },
        ///       "icePreference": { None = 1, Light = 2, Regular = 3, Extra = 4 },
        ///       "hasSugar": false,
        ///       "hasLemon": true,
        ///       "quantity": 1
        ///     }
        /// </remarks>
        /// <param name="order">Details of the drink order.</param>
        /// <returns>Message indicating the success of the drink order.</returns>
        /// <response code="200">Drink order received successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("/drink")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult OrderDrink([FromBody] DrinkOrderDto order)
        {
            try
            {
                _drinkOrderService.SendDrinkOrder(order);
                return Ok("Drink order received successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
