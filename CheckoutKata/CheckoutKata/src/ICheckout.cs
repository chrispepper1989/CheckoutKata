using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    interface ICheckout
    {
        void Scan(string sku);
        int GetTotalPrice();
    }


  
    class Checkout : ICheckout
    {
        private List<string> _items = new List<string>();
        
        
        public void Scan(string sku)
        {
            _items.Add(sku);
        }
        
        
        
        public int GetTotalPrice()
        {
            var skuGroups = _items.GroupBy(id => id);
            foreach (var skuGroup in skuGroups)
            {
                var skuId = skuGroup.Key;
                var itemPrice = GetPriceRules(skuId);
            }
        }

        private List<IPriceRule> GetPriceRules(string skuId)
        {
            return new List<IPriceRule> {new RegularPrice()};
        }
    }

    internal interface IPriceRule
    {
        //price is represented in pence
        int GetPrice(int unitPrice, int unitCount);
    }

    class RegularPrice : IPriceRule
    {
        public int GetPrice(int unitPrice, int unitCount)
        {
            return unitCount * unitPrice;
        }
    }
}