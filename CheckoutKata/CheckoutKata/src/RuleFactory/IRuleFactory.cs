using System.Collections.Generic;

namespace CheckoutKata
{
    public interface IRuleFactory
    {
        List<IPriceRule> GetDefaultRules();
        IPriceRule GetPriceRule(RuleEnum rule);
    }
}