using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory
{
    // Creator 
    // This can be an abstract class to force all subclasses to implement heir own versions of the method
    // , as alternative the base factory method can return some default product type
    public interface IPaybackSchemeFactory
    {
        IPaybackScheme Create(Loan loan);
    }
}
