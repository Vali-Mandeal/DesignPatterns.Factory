using System.Collections.Generic;
using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Data
{
    // In memory DB with ThreadSafe Singleton
    public class Context
    {
        private static Context _instance;
        private static readonly object _lock = new();
        private Context() { }

        public static Context GetInstance() 
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Context();
                    }
                }
            }

            return _instance;
        }
        public List<LoanType> GetLoanTypes()
        {
            return new List<LoanType>
            {
                new LoanType {Id = 1, Name = "Housing Loan", InterestRatePerYear = 3.5M},
                new LoanType {Id = 2, Name = "Car Loan", InterestRatePerYear = 7M}
            };
        }
    }
}
