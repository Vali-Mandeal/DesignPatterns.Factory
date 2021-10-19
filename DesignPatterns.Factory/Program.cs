using System;
using System.Linq;
using DesignPatterns.Factory.Entities;
using DesignPatterns.Factory.Services;

namespace DesignPatterns.Factory
{
    class Program
    {
        private static IPaybackPlanService _paybackPlanService;
        private static ILoanService _loanService;
        static void Main() 
        {
            _paybackPlanService = new PaybackPlanService();
            _loanService = new LoanService();
            Greetings();

            var loan = new Loan();

            ReadAmount(loan);
            ReadDuration(loan);
            ReadLoanType(loan);

            var paybackPlan = _paybackPlanService.GetPaybackPlan(loan);

            PrintPaybackPlan(paybackPlan);
            Console.SetCursorPosition(0, 0);
        }

        #region ConsoleReadZone
        private static void Greetings()
        {
            Console.WriteLine(
                @"Aloha, this banking app tells you how much you're going to pay back each month for a loan. 
The calculation is based on your desired amount, loan type and payback duration.");
        }

        private static void ReadDuration(Loan loan)
        {
            Console.WriteLine("Please write the payback duration (in years): \n");
            loan.DurationInYears = Convert.ToInt32(Console.ReadLine());
        }

        private static void ReadAmount(Loan loan)
        {
            Console.WriteLine("Please write the desired amount: \n");
            loan.Amount = Convert.ToDecimal(Console.ReadLine());
        }

        private static void ReadLoanType(Loan loan)
        {
            Console.WriteLine("Please choose a loan type:");
            var loanTypes = _loanService.GetLoanTypes();

            foreach (var loanType in loanTypes.Select((value, index) => (value, index)))
            {
                Console.WriteLine($"{loanType.index} - {loanType.value.Name} has an {loanType.value.InterestRatePerYear} interest rate per year.");
            }

            var selection = Convert.ToInt32(Console.ReadLine());

            loan.Type = loanTypes.ToList()[selection];
        }
        #endregion

        #region ConsoleWriteZone
        private static void PrintPaybackPlan(PaybackPlan paybackPlan)
        {
            PrintPlanHeader();

            PrintPlanPayments(paybackPlan);

            PrintPlanSummary(paybackPlan);
        }

        private static void PrintPlanHeader()
        {
            Console.WriteLine();
            Console.WriteLine(GetPaybackPlanFormatString(), "Month", "Principal", "Interest Amount", "Total", "Unpaid Balance");
        }

        private static string GetPaybackPlanFormatString(bool containsMonth = true)
        {
            return containsMonth
                ? "{0,0} {1,20} {2,30} {3, 20} {4,30}\n"
                : "{0,0} {1,20} {2,30}\n";
        }

        private static void PrintPlanSummary(PaybackPlan paybackPlan)
        {
            Console.WriteLine("\nSummary:\n");
            Console.WriteLine(GetPaybackPlanFormatString(false), "Principal", "Interest Amount", "Total");

            var summary = paybackPlan.PaymentSummary;
            Console.WriteLine(GetPaybackPlanFormatString(false),
                $"{Math.Round(summary.Principal, 2, MidpointRounding.AwayFromZero)}",
                $"{Math.Round(summary.InterestAmount, 2, MidpointRounding.AwayFromZero)}",
                $"{Math.Round(summary.Total, 2, MidpointRounding.AwayFromZero)}");
        }

        private static void PrintPlanPayments(PaybackPlan paybackPlan)
        {
            foreach (var payment in paybackPlan.Payments)
            {
                Console.WriteLine(GetPaybackPlanFormatString(),
                    $"{payment.Month}",
                    $"{Math.Round(payment.Principal, 2, MidpointRounding.AwayFromZero)}",
                    $"{Math.Round(payment.InterestAmount, 2, MidpointRounding.AwayFromZero)}",
                    $"{Math.Round(payment.Total, 2, MidpointRounding.AwayFromZero)}",
                    $"{Math.Round(payment.UnpaidBalanceAtThisPoint, 2, MidpointRounding.AwayFromZero)}");
            }
        }
        #endregion
    }
}
