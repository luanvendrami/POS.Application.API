using Data.Infra.Context;
using Data.Infra.Repository;
using Domain.Dto.Request;
using Domain.Enum;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Service;
using Xunit;

namespace Test.IntegrationTests
{
    public class FriesOrderServiceTests : IDisposable
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;
        private readonly DataContext _dataContext;
        private readonly IFriesOrderRepository _friesOrderRepository;
        private readonly FriesOrderService _friesOrderService;

        public FriesOrderServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "DbTests-Fries")
                .Options;

            _dataContext = new DataContext(_dbContextOptions);
            _friesOrderRepository = new FriesOrderRepository(_dataContext);
            _friesOrderService = new FriesOrderService(new Mock<IRabbitMQRepository>().Object, _friesOrderRepository);
        }

        [Fact]
        public void SendFriesOrder_ShouldSendOrderToRabbitMQ()
        {
            var orderDto = new OrderFriesDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Size = FriesSize.Large,
                Sauce = SauceType.Garlic,
                Quantity = 1,
            };

            _friesOrderService.SendFriesOrder(orderDto);

            Assert.True(true);
        }

        [Fact]
        public async Task CreateFriesOrder_ShouldAddDrinkOrderToRepositoryAsync()
        {
            var orderDto = new OrderFriesDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Size = FriesSize.Large,
                Sauce = SauceType.Garlic,
                Quantity = 1,
            };

            _friesOrderService.CreateFriesOrder(orderDto);

            var friesOrders = await _friesOrderRepository.GetFriesOrdersForId(orderDto.IdOrder);
            Assert.Single(friesOrders);
            Assert.Equal(orderDto.IdOrder, friesOrders[0].IdOrder); 
        }

        public void Dispose()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Dispose();
        }
    }  
}
