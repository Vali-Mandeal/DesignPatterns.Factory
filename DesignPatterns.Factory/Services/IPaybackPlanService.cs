using DesignPatterns.Factory.Entities;

namespace DesignPatterns.Factory.Services
{
    public interface IPaybackPlanService
    {
        PaybackPlan GetPaybackPlan(Loan loan);
    }
}
