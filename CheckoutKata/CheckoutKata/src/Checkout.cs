using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    
    class Checkout : ICheckout
    {
        public Checkout( Dictionary<string, int>  priceCatalogue, Func<int, int, int> winningPriceStrat)
        {
            _winningPriceStrat = winningPriceStrat;
            _priceCatalogue = priceCatalogue;
        }
        
        public Checkout( Dictionary<string, int>  priceCatalogue) : this(priceCatalogue, 
            (oldPrice, newPrice) => oldPrice < newPrice ? oldPrice : newPrice)   //assume lowest price wins as default
        { }
       

        private readonly Func<int, int, int> _winningPriceStrat;
        private readonly Dictionary<string, int>  _priceCatalogue;
        
        private List<string> _items = new List<string>();
        
        public void Scan(string sku)
        {
            _items.Add(sku);
        }
        
        public int GetTotalPrice()
        {
            int totalPrice = 0;
            var skuGroups = _items.GroupBy(id => id);
            foreach (var skuGroup in skuGroups)
            {
                var skuId = skuGroup.Key;
                var skuUnitPrice = GetUnitPrice(skuId);
                var skuNumberOfUnits = skuGroup.Count();
                var itemPrice = GetPriceRules(skuId);
                int best = int.MaxValue; 
                
                foreach (var priceRule in itemPrice)
                {
                    var newPrice = priceRule.GetPrice(unitPrice: skuUnitPrice, unitCount: skuNumberOfUnits);
                    best = _winningPriceStrat(best, newPrice);
                    totalPrice += best;
                }
            }
            
            return totalPrice;
        }

        private int GetUnitPrice(string skuId)
        {
            return _priceCatalogue[skuId];
        }

        private List<IPriceRule> GetPriceRules(string skuId)
        {
            return new List<IPriceRule> {new RegularPrice()};
        }
    }
}