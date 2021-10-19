using System.Collections.Generic;
using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services
{
    public interface ILoanService
    {
        IEnumerable<LoanType> GetLoanTypes();
    }
}
