using System;
using System.Collections.Generic;
using FluentAssertions;
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


        private Checkout checkout = new Checkout();

            /*
             * SKU	Unit Price	Special Price
                A	50	3 for 130
                B	30	2 for 45
                C	20	
                D	10	
             */
        [Fact]
        public void When_NoSpecialBuy_TotalIsRegularPrice()
        {
            //arrange
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