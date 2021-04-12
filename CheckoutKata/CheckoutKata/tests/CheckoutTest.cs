using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace CheckoutKata
{
    public class CheckoutTest
    {
       
        [Fact]
        public void When_NoSpecialBuy_TotalIsRegularPrice()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 50},
                {"Pepsi", 30}
            };
            Checkout checkout = new Checkout(skuPrices);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Pepsi");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(80);

        }
    }
}