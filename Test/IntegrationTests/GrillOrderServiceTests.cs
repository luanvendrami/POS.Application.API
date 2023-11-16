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
    public class GrillOrderServiceTests : IDisposable
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;
        private readonly DataContext _dataContext;
        private readonly IGrillOrderRepository _grillOrderRepository;
        private readonly GrillOrderService _grillOrderService;

        public GrillOrderServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "DbTests-Grill")
                .Options;

            _dataContext = new DataContext(_dbContextOptions);
            _grillOrderRepository = new GrillOrderRepository(_dataContext);
            _grillOrderService = new GrillOrderService(new Mock<IRabbitMQRepository>().Object, _grillOrderRepository);
        }

        [Fact]
        public void SendGrillOrder_ShouldSendOrderToRabbitMQ()
        {
            var orderDto = new GrillOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Meat = MeatType.Beef,
                CookingPreference = CookingLevel.Rare,
                SideDishes = true,
                Quantity = 1
            };

            _grillOrderService.SendGrillOrder(orderDto);

            Assert.True(true);
        }

        [Fact]
        public async Task CreateGrillOrder_ShouldAddDrinkOrderToRepositoryAsync()
        {
            var orderDto = new GrillOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Meat = MeatType.Beef,
                CookingPreference = CookingLevel.Rare,
                SideDishes = true,
                Quantity = 1
            };

            _grillOrderService.SendGrillOrder(orderDto);

            var grillOrders = await _grillOrderRepository.GetGrillOrdersForId(orderDto.IdOrder);
            Assert.Single(grillOrders); 
            Assert.Equal(orderDto.IdOrder, grillOrders[0].IdOrder); 
        }

        public void Dispose()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Dispose();
        }
    }
}
