using System;
using DesignPatterns.Factory.Entities;
using DesignPatterns.Factory.Services.PaybackSchemesFactory.Concrete;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory
{
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
