using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services.PaybackSchemesFactory.Concrete
{
    public class EvenPrincipal : IPaybackScheme
    {
        private readonly PaybackSchemeBase _paybackSchemeBase;

        public EvenPrincipal()
        {
            _paybackSchemeBase = new PaybackSchemeBase();
        }
        public PaybackPlan ProcessPaybackPlan(Loan loan)
        {
            var fixedMonthlyPrincipal = GetFixedMonthlyPrincipal(loan.DurationInYears, loan.Amount);
            var monthlyInterestRate = _paybackSchemeBase.GetInterestRatePerMonth(loan.Type.InterestRatePerYear);

            var paybackPlan = GetPaybackPlan(loan.Amount, monthlyInterestRate, fixedMonthlyPrincipal);

            return paybackPlan;
        }

        private PaybackPlan GetPaybackPlan(
            decimal unpaidBalance,
            decimal monthlyInterestRate,
            decimal fixedMonthlyPrincipal)
        {
            var paybackPlan = new PaybackPlan();
            var paymentMonthCounter = 1;

            while (unpaidBalance > 0)
            {
                var payment = new Payment
                {
                    InterestAmount =
                        _paybackSchemeBase.GetMonthlyInterestAmount(monthlyInterestRate, unpaidBalance),
                    Principal = fixedMonthlyPrincipal
                };

                payment.Total = GetTotalPayment(payment.InterestAmount, payment.Principal);
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

        private static decimal GetFixedMonthlyPrincipal(int loanDurationInYears, decimal loanAmount)
        {
            const int monthsPerYear = 12;
            return loanAmount / (loanDurationInYears * monthsPerYear);
        }

        private static decimal GetTotalPayment(decimal interestAmount, decimal principal)
            => interestAmount + principal;
    }
}
