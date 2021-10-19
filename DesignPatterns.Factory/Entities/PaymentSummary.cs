using System;

namespace DesignPatterns.Factory.Entities
{
    public class PaymentSummary
    {
        public PaymentSummary()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public decimal Principal { get; set; }
        public decimal InterestAmount { get; set; }
    }
}
