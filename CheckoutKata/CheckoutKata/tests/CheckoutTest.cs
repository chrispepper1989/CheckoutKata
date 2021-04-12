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
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new RegularPrice());
            skuPriceRules["Pepsi"] = new List<IPriceRule>();
            skuPriceRules["Pepsi"].Add(new RegularPrice());
         
            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Pepsi");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(80);

        }
    }
}