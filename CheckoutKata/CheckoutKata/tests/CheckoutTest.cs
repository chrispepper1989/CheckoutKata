using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace CheckoutKata
{
    public class CheckoutTest
    {
        struct SKU
        {
            public readonly string Id;
            public readonly int UnitPrice;

            public SKU(string id, int unitPrice)
            {
                Id = id;
                UnitPrice = unitPrice;
            }
        }

        class TestDictionaryBased : IUnitPriceCatalogue
        {
            private Dictionary<string, int> prices = new Dictionary<string, int>();

            TestDictionaryBased()
            {
                prices["Coke"] = 50;
                prices["Pepsi"] = 30;
            }
            
            public int GetUnitPrice(string sku)
            {
                return prices[sku];
            }
        }
        private 
       
        [Fact]
        public void When_NoSpecialBuy_TotalIsRegularPrice()
        {
            //arrange
            Mock<IUnitPriceCatalogue> priceCatalogue = new Mock<IUnitPriceCatalogue>();
            priceCatalogue.Setup(x => x.GetUnitPrice("Coke")).Returns(50);
            Checkout checkout = new Checkout(priceCatalogue.Object);
            List<SKU> testData = new List<SKU>
            {
                new SKU(id:"Coke", unitPrice:50 ),
                new SKU(id:"Pepsi", unitPrice:30 )
            };
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Pepsi");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(80);

        }
    }
}