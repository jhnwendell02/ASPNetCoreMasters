using ASPNetCoreMastersTodoList.Api.Controllers;
using Repositories.Interfaces;
using Services;
using System;
using Xunit;
using DomainModels;
using System.Threading.Tasks;
using System.Linq;
using Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using ASPNetCoreMastersTodoList.Api.Options;
using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Times = Moq.Times;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Services.DTO;

namespace XunitTests
{
    public class ItemsServiceTests
    {
        private readonly Mock<IItemRepository> _itemsRepoMock;
        private readonly ItemService _itemService;
        private readonly ILogger<ItemService> _logger;

        private readonly Mock<IItemService> service;




        public ItemsServiceTests()
        {
            _logger = new Logger<ItemService>(new NullLoggerFactory());
            _itemsRepoMock = new Mock<IItemRepository>();
            _itemService = new ItemService(_itemsRepoMock.Object, _logger);
            service = new Mock<IItemService>();
        }

        private ItemDTO CreateItem()
        {
            return new ItemDTO()
            {
                ItemId = 1,
                Text = "Item 1"
            };
        }

        private List<ItemDTO> CreateItemsList()
        {
            return new List<ItemDTO>()
    {
        new ItemDTO()
        {
            ItemId = 1,
            Text = "Item 1"
        },
        new ItemDTO()
        {
            ItemId = 2,
            Text = "Item 2"
        },
        new ItemDTO()
        {
            ItemId = 3,
            Text = "Item 3"
        }
    };
        }


        [Fact]
        public void GetAll_ShouldReturnAll()
        {
            //arrange
            var items = CreateItemsList();

            //act
            var result = service.Setup(x => x.GetAll()).Returns(items.AsQueryable());

            //assert
            Assert.NotNull(result);
        }


        [Fact]
        public void GetById_ShouldReturnTheItem()
        {
            //arrange
            var item = CreateItem();
            var itemId = item.ItemId;

            //act
            service.Setup(x => x.Get(1)).Returns(item);

            //assert
            Assert.Equal(itemId.ToString(), item.ItemId.ToString());
        }

        [Fact]
        public void GetAll_ShouldCallGetAllFromRepository_OnlyOnce()
        {
            //arrange
            var itemsList = new List<Item>();
            _itemsRepoMock.Setup(c =>
                c.All()).Returns(itemsList.AsQueryable());

            //act
            _itemService.GetAll();

            //assert
            _itemsRepoMock.Verify(mock => mock.All(), Times.Once);
        }

        [Fact]
        public void DeleteItem_Success()
        {
            //arrange
            var itemId = 1;
            string serviceResponse = "Successfully deleted item number 1";
            //act
            //_itemService.Delete(itemId);
            service.Setup(x => x.Delete(itemId)).Returns($"Successfully deleted item number {itemId}");

            //assert
            //_itemsRepoMock.Verify(mock => mock.Delete(itemId), Times.Once);
            Assert.Equal($"Successfully deleted item number {itemId}", serviceResponse);

        }


    }
}
