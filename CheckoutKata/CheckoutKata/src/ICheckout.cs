namespace CheckoutKata
{
    interface ICheckout
    {
        void Scan(string sku);
        int GetTotalPrice();
    }
}