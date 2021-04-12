using System.Collections.Generic;

namespace CheckoutKata
{
    //todo tests and how would this work with generic price rules e.g. Buy X get Y
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