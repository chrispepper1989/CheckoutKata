namespace CheckoutKata
{
    class BuyXForValue: IPriceRule
    {
        private int x_UnitTrigger;
        private int y_specialUnitPrice;

        public BuyXForValue(int xUnitTrigger, int ySpecialUnitPrice)
        {
            this.x_UnitTrigger = xUnitTrigger;
            this.y_specialUnitPrice = ySpecialUnitPrice;
        }
        
        public int GetPrice(int unitPrice, int unitCount)
        {
            int nOutSideOfOfer = unitCount % x_UnitTrigger;
            int nInsideOfOffer = unitCount/x_UnitTrigger;

            var outSideOfferTotal = nOutSideOfOfer * unitPrice;
            var insideOfferTotal = nInsideOfOffer * y_specialUnitPrice;
            return outSideOfferTotal + insideOfferTotal;
        }
    }
}