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
            checkout.GetTotalPrice().Should().Be(100);
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
        
        
        [Fact]
        [Trait("Category","3 For £1")]
        public void When_3For1Pound_With3Items_TotalIs1Pound()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 80},
            };
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new BuyXForValue(3, 100));
         
            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(100);
        }
        [Fact]
        [Trait("Category","3 For £1")]
        public void When_3For1Pound_With5Items_TotalIs1PoundPlus2Items()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 80},
            };
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new BuyXForValue(3, 100));
         
            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            checkout.Scan("Coke");
            
            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(230);
        }
        
        [Fact]
        [Trait("Category","3 For £1")]
        public void When_3For1Pound_With2Items_RegularPriceApplied()
        {
            //arrange
            var skuPrices = new Dictionary<string, int>() 
            {
                {"Coke", 80},
            };
            var skuPriceRules = new Dictionary<string, List<IPriceRule>>();
            skuPriceRules["Coke"] = new List<IPriceRule>();
            skuPriceRules["Coke"].Add(new BuyXForValue(3, 100));
         
            Checkout checkout = new Checkout(skuPrices,skuPriceRules);
            
            //act
            checkout.Scan("Coke");
            checkout.Scan("Coke");

            //assert
            //should be simple sum
            checkout.GetTotalPrice().Should().Be(130);
        }
    }
}