using System.Collections.Generic;
using DesignPatterns.Factory.Data;
using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services
{
    public class LoanService : ILoanService
    {
        public IEnumerable<LoanType> GetLoanTypes()
        {
            var context = Context.GetInstance();
            return context.GetLoanTypes();
        }
    }
}
