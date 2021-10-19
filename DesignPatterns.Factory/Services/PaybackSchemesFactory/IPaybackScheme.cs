using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory
{
    public interface IPaybackScheme
    {
        PaybackPlan ProcessPaybackPlan(Loan loan);
    }
}
