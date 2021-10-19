using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory
{
    // Product Abstraction
    // All Concrete Product Implementations should inherit this
    public interface IPaybackScheme
    {
        PaybackPlan ProcessPaybackPlan(Loan loan);
    }
}
