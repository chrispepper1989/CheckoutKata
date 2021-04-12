namespace CheckoutKata
{
    public interface IPriceRule
    {
        //price is represented in pence
        int GetPrice(int unitPrice, int unitCount);
    }
}