namespace CheckoutKata
{
    interface ICheckout
    {
        void Scan(string sku);
        int GetTotalPrice();
    }

    class Checkout : ICheckout
    {
        public void Scan(string sku)
        {
            throw new System.NotImplementedException();
        }

        public int GetTotalPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}