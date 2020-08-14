using System;
using System.Linq;

namespace UnitTesting.Basics
{
    public class LoanCalculatorService
    {
        private readonly ILoansRepository loansRepository;
        private readonly LoanCalculator loanCalculator;

        public LoanCalculatorService(ILoansRepository loansRepository, LoanCalculator loanCalculator)
        {
            this.loansRepository = loansRepository ?? throw new ArgumentNullException(nameof(this.loansRepository));
            this.loanCalculator = loanCalculator ?? throw new ArgumentNullException(nameof(loanCalculator));
        }

        // memberIds = [1,2,3,4]
        public void Run(int[] memberIds)
        {
            // We start with a list of member
            var memberDetails = loansRepository.GetMemberDetails(memberIds);

            // 1. Get the members contributions
            foreach (var memberDetail in memberDetails)
            {
                var contributions = loansRepository.GetMemberContributions(memberDetail.Id);

                // Get the loan amount
                var totalContributions = contributions.Payments.Sum();
                var loanAmount = loanCalculator.GetLoanAmount(totalContributions);

                // Get the boost amount
                var boostLoanAmount = loanCalculator.GetBoostLoanAmount(memberDetail.MembershipTerm);

                // Sum them up
                var total = loanAmount + boostLoanAmount;

                loansRepository.SaveMemberLoan(memberDetail.Id,  total);
            }
        }
    }
}
