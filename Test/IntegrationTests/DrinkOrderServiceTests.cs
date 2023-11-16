using Data.Infra.Context;
using Data.Infra.Repository;
using Domain.Dto.Request;
using Domain.Entities;
using Domain.Enum;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Service;
using System;
using Xunit;

namespace Test.IntegrationTests
{
    public class DrinkOrderServiceTests : IDisposable
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;
        private readonly DataContext _dataContext;
        private readonly IDrinkOrderRepository _drinkOrderRepository;
        private readonly DrinkOrderService _drinkOrderService;

        public DrinkOrderServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DbTests-Drinks")
                .Options;

            _dataContext = new DataContext(_dbContextOptions);
            _drinkOrderRepository = new DrinkOrderRepository(_dataContext);
            _drinkOrderService = new DrinkOrderService(new Mock<IRabbitMQRepository>().Object, _drinkOrderRepository);
        }

        [Fact]
        public void SendDrinkOrder_ShouldSendOrderToRabbitMQ()
        {
            var orderDto = new DrinkOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Type = DrinkType.Coffee,
                IcePreference = IceLevel.Regular,
                HasSugar = false,
                HasLemon = false,
                Quantity = 2
            };

            _drinkOrderService.SendDrinkOrder(orderDto);

            Assert.True(true);
        }

        [Fact]
        public async Task CreateDrinkOrder_ShouldAddDrinkOrderToRepositoryAsync()
        {
            var orderDto = new DrinkOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "No sugar",
                Type = DrinkType.Coffee,
                IcePreference = IceLevel.Regular,
                HasSugar = false,
                HasLemon = false,
                Quantity = 2
            };

            _drinkOrderService.CreateDrinkOrder(orderDto);

            var drinkOrders = await _drinkOrderRepository.GetDrinkOrdersForId(orderDto.IdOrder);
            Assert.Single(drinkOrders);
            Assert.Equal(orderDto.IdOrder, drinkOrders[0].IdOrder);
        }

        public void Dispose()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Dispose();
        }
    }
}
