using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory
{
    public interface IPaybackSchemeFactory
    {
        IPaybackScheme Create(Loan loan);
    }
}
