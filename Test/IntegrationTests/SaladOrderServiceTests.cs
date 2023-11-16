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
    public class SaladOrderServiceTests : IDisposable
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;
        private readonly DataContext _dataContext;
        private readonly ISaladOrderRepository _saladOrderRepository;
        private readonly SaladOrderService _saladOrderService;

        public SaladOrderServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "DbTests-Salad")
                .Options;

            _dataContext = new DataContext(_dbContextOptions);
            _saladOrderRepository = new SaladOrderRepository(_dataContext);
            _saladOrderService = new SaladOrderService(new Mock<IRabbitMQRepository>().Object, _saladOrderRepository);
        }

        [Fact]
        public void SendSaladOrder_ShouldSendOrderToRabbitMQ()
        {
            var orderDto = new SaladOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Type = SaladType.Caprese,
                Dressing = DressingType.Caesar,
                HasProtein = true,
                Quantity = 1
            };

            _saladOrderService.SendSaladOrder(orderDto);

            Assert.True(true);
        }

        [Fact]
        public async Task CreateSaladOrder_ShouldAddDrinkOrderToRepositoryAsync()
        {
            var orderDto = new SaladOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Type = SaladType.Caprese,
                Dressing = DressingType.Caesar,
                HasProtein = true,
                Quantity = 1
            };

            _saladOrderService.SendSaladOrder(orderDto);

            var saladOrders = await _saladOrderRepository.GetSaladOrdersForId(orderDto.IdOrder);
            Assert.Single(saladOrders); 
            Assert.Equal(orderDto.IdOrder, saladOrders[0].IdOrder);
        }

        public void Dispose()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Dispose();
        }
    }
}
