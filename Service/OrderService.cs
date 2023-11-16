using AutoMapper;
using Domain.Dto.Request;
using Domain.Dto.Response;
using Domain.Interface.Repository;
using Domain.Interface.Service;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;

        private readonly IDrinkOrderRepository _drinkOrderRepository;
        private readonly IFriesOrderRepository _friesOrderRepository;
        private readonly IGrillOrderRepository _grillOrderRepository;
        private readonly ISaladOrderRepository _saladOrderRepository;

        public OrderService(IMapper mapper, IDrinkOrderRepository drinkOrderRepository, IFriesOrderRepository friesOrderRepository, IGrillOrderRepository grillOrderRepository, ISaladOrderRepository saladOrderRepository)
        {
            _mapper = mapper;

            _drinkOrderRepository = drinkOrderRepository;
            _friesOrderRepository = friesOrderRepository;
            _grillOrderRepository = grillOrderRepository;
            _saladOrderRepository = saladOrderRepository;
        }

        public async Task<OrderDataReponseDto> GetOrdersForId(int idOrder)
        {
            var drinks = await _drinkOrderRepository.GetDrinkOrdersForId(idOrder);
            var fries = await _friesOrderRepository.GetFriesOrdersForId(idOrder);
            var grills = await _grillOrderRepository.GetGrillOrdersForId(idOrder);
            var salads = await _saladOrderRepository.GetSaladOrdersForId(idOrder);

            var response = new OrderDataReponseDto(
                _mapper.Map<List<DrinkOrderDto>>(drinks),
                _mapper.Map<List<GrillOrderDto>>(grills),
                _mapper.Map<List<OrderFriesDto>>(fries),
                _mapper.Map<List<SaladOrderDto>>(salads));

            return response;
        }
    }
}
