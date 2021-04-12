namespace CheckoutKata
{
    class RegularPrice : IPriceRule
    {
        public int GetPrice(int unitPrice, int unitCount)
        {
            return unitCount * unitPrice;
        }
    }
}