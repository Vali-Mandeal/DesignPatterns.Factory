using System;
using DesignPatterns.Factory.Entities;
using DesignPatterns.Factory.Services.PaybackSchemesFactory.Concrete;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory
{
    // Concrete Creator Implementation

    // There can be more creators

    // Concrete Creators override the base factory method so it returns a different type of product.

    // Note that the factory method doesn’t have to create new instances all the time.
    // It can also return existing objects from a cache, an object pool, or another source.
    public class PaybackSchemeFactory : IPaybackSchemeFactory
    {
        public IPaybackScheme Create(Loan loan)
        {
            return loan.Type.Id switch
            {
                1 => new EvenPrincipal(),
                2 => new EvenTotalPayment(),
                _ => throw new IndexOutOfRangeException()
            };
        }
    }
}
