namespace DesignPatterns.Factory.Services.PaybackSchemesFactory.Concrete
{
    // Not part of Factory Pattern
    // Just the common methods are extracted here
    public class PaybackSchemeBase
    {
        public decimal GetInterestRatePerMonth(decimal percentageAnnualRate)
        {
            const int monthsPerYear = 12;
            return ((percentageAnnualRate / 100) / monthsPerYear);
        }

        public decimal GetUnpaidBalance(decimal oldUnpaidBalance, decimal totalPayment)
            => oldUnpaidBalance - totalPayment;

        public decimal GetMonthlyInterestAmount(decimal interestRatePerMonth, decimal unpaidBalance)
            => interestRatePerMonth * unpaidBalance;
    }
}
