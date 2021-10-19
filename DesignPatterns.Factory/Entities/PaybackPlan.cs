using System;
using System.Collections.Generic;

namespace DesignPatterns.Factory.Entities
{
    public class PaybackPlan
    {
        public PaybackPlan()
        {
            Id = Guid.NewGuid();
            Payments = new List<Payment>();
            PaymentSummary = new PaymentSummary();
        }
        public Guid Id { get; set; }
        public List<Payment> Payments { get; set; }
        public PaymentSummary PaymentSummary { get; set; }
    }
}
