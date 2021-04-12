namespace CheckoutKata
{
    class BuyOneGetOneFree  : IPriceRule
    {
        public int GetPrice(int unitPrice, int unitCount)
        {
            /*
             * Buy one get one free is essentially
             if(unit is even)
                price is (unit * regularPrice) / 2
            else
                price is ((unit - 1) * regularPrice) / 2) + (1 * regularPrice)
             * 
             */
            
            var even = unitCount % 2; 
            var evenBalance = even; //if its even, then this will be 0 and cancel out in the formula
            
            var price = (((unitCount - evenBalance) * unitPrice) / 2) + (evenBalance * unitPrice);
            return price;
        }
    }
}