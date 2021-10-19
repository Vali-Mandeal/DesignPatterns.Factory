using System;

namespace DesignPatterns.Factory.Entities
{
    public class Payment
    {
        public Payment()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int Month { get; set; }
        public decimal Total { get; set; }
        public decimal Principal { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal UnpaidBalanceAtThisPoint { get; set; }
    }
}
