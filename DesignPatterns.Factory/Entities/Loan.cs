using System;

namespace DesignPatterns.Factory.Entities
{
    public class Loan
    {
        public Loan()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int DurationInYears { get; set; }
        public decimal Amount { get; set; }
        public LoanType Type { get; set; }
    }
}
