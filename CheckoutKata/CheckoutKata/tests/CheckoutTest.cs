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
        [Trait("Category","RegularPrice")]
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
        
        
        [Fact]
        [Trait("Category","RegularPrice")]
        public void When_OneItem_WithRegularPrice_TotalIsUnitPrice()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 50},
            };
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new RegularPrice()); //todo definitely feels like reg price should be added by default

            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(50);
        }
        
        [Fact]
        [Trait("Category","BuyOneGetOneFree")]
        public void When_BuyOneGetOneFree_With_2_Items_TotalIsHalf()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 50},
            };
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new RegularPrice()); 
            skuPriceRules["Coke"].Add(new BuyOneGetOneFree());
         
            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(50);
        }
        
        [Fact]
        [Trait("Category","BuyOneGetOneFree")]
        public void When_BuyOneGetOneFree_With_3_Items_TotalIsHalfPlus1()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 50},
            };
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new RegularPrice()); 
            skuPriceRules["Coke"].Add(new BuyOneGetOneFree());
         
            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(100);
        }
    }
}