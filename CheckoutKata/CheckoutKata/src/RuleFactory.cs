using System.Collections.Generic;

namespace CheckoutKata
{
    public enum RuleEnum
    {
        BuyOneGetOneFree,
        RegularPrice
    }
    public interface IRuleFactory
    {
        List<IPriceRule> GetDefaultRules();
        IPriceRule GetPriceRule(RuleEnum rule);
    }
    public class RuleFactory : IRuleFactory
    {
        public List<IPriceRule> GetDefaultRules()
        {
            throw new System.NotImplementedException();
        }

        public IPriceRule GetPriceRule(RuleEnum rule)
        {
            throw new System.NotImplementedException();
        }
    }
}