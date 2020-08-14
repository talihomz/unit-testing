namespace UnitTesting.Basics
{
    public class LoanCalculator
    {
        public int GetLoanAmount(int memberContributions)
        {
            if (memberContributions < 15000)
                return 15000;
            
            if (memberContributions < 50000)
                return 75000;
            
            if (memberContributions < 100000)
                return 150000;

            return 500000;
        }

        public int GetBoostLoanAmount(double memberTerm)
        {
            if (memberTerm < 1)
                return 10000;

            if (memberTerm < 2)
                return 35000;

            if (memberTerm < 5)
                return 100000;

            return 250000;
        }
    }
}