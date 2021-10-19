using System;
using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory.Concrete
{
    // Concrete Product Implementation
    public class EvenTotalPayment : IPaybackScheme
    {
        private readonly PaybackSchemeBase _paybackSchemeBase;

        public EvenTotalPayment()
        {
            _paybackSchemeBase = new PaybackSchemeBase();
        }

        public PaybackPlan ProcessPaybackPlan(Loan loan)
        {
            var fixedMonthlyTotal = GetFixedMonthlyTotal(
                loan.Type.InterestRatePerYear, loan.Amount, loan.DurationInYears);

            var interestRatePerMonth = _paybackSchemeBase.GetInterestRatePerMonth(loan.Type.InterestRatePerYear);

            var paybackPlan = GetPaybackPlan(loan.Amount, interestRatePerMonth, fixedMonthlyTotal);

            return paybackPlan;
        }

        private PaybackPlan GetPaybackPlan(
            decimal unpaidBalance,
            decimal interestRatePerMonth,
            decimal fixedMonthlyTotalAmount)
        {
            var paybackPlan = new PaybackPlan();
            var paymentMonthCounter = 1;

            while (unpaidBalance > 0)
            {
                var payment = new Payment();

                payment.InterestAmount =
                    _paybackSchemeBase.GetMonthlyInterestAmount(interestRatePerMonth, unpaidBalance);
                payment.Total = fixedMonthlyTotalAmount;
                payment.Principal = GetMonthlyPrincipal(payment.InterestAmount, payment.Total);
                payment.Month = paymentMonthCounter++;

                payment.UnpaidBalanceAtThisPoint
                    = unpaidBalance
                        = _paybackSchemeBase.GetUnpaidBalance(unpaidBalance, payment.Principal);

                paybackPlan.Payments.Add(payment);

                paybackPlan.PaymentSummary.InterestAmount += payment.InterestAmount;
                paybackPlan.PaymentSummary.Principal += payment.Principal;
                paybackPlan.PaymentSummary.Total += payment.Total;
            }

            return paybackPlan;
        }

        private static decimal GetMonthlyPrincipal(decimal paymentInterestAmount, decimal paymentTotal)
            => paymentTotal - paymentInterestAmount;

        private static decimal GetFixedMonthlyTotal(
            decimal interestRatePerYear,
            decimal loanAmount,
            decimal loanDurationInYears)
        {
            const int monthsPerYear = 12;
            var decimalInterestRate = interestRatePerYear / 100;


            return ((decimalInterestRate * loanAmount)
                    / (1 - (decimal)Math.Pow(1 + (double)decimalInterestRate, (double)-loanDurationInYears)))
                   / monthsPerYear;
        }
    }
}
