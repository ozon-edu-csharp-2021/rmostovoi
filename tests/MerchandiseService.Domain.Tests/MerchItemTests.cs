using System;
using FluentAssertions;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchItemsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Valid_quantity_created_successfully(long quantity)
        {
            var quantityVO = new Quantity(quantity);
            quantityVO.Should().NotBeNull();
        }
        
        [Fact]
        public void Negative_quantity_creation_is_invalid()
        {
            new Func<Quantity>(() => new Quantity(-1))
                .Should().Throw<VOValidationException>();
        }
        
        [Theory]
        [InlineData(5, 1)]
        [InlineData(5, 4)]
        [InlineData(5, 5)]
        [InlineData(1, 1)]
        public void Merch_item_can_be_issued(long quantity, long inquiriedQuantity)
        {
            var merchItem = CreateMerchItem(quantity);
            merchItem.CanBeIssued(new Quantity(inquiriedQuantity))
                .Should().BeTrue();
        }
        
        [Theory]
        [InlineData(5, 6)]
        [InlineData(0, 1)]
        public void Merch_item_cannot_be_issued(long quantity, long inquiriedQuantity)
        {
            var merchItem = CreateMerchItem(quantity);
            merchItem.CanBeIssued(new Quantity(inquiriedQuantity))
                .Should().BeFalse();
        }

        private static MerchItem CreateMerchItem(long quantity)
        {
            return new MerchItem(
                MerchItemId.New(),
                new Sku(1),
                new MerchItemName("Футболка"),
                new Quantity(quantity),
                ClothingSize.L
            );
        }
    }
}