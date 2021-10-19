using DesignPatterns.Factory.Entities;
using DesignPatterns.Factory.Services.PaybackSchemesFactory;

namespace DesignPatterns.Factory.Services
{
    public class PaybackPlanService : IPaybackPlanService
    {
        public PaybackPlan GetPaybackPlan(Loan loan)
        {
            var factory = new PaybackSchemeFactory();
            var paybackScheme = factory.Create(loan);

            return paybackScheme.ProcessPaybackPlan(loan);
        }
    }
}
