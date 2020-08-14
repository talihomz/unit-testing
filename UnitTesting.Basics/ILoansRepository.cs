using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting.Basics
{
    public interface ILoansRepository
    {
        MemberDetails[] GetMemberDetails(int[] id);
        MemberContributions GetMemberContributions(int id);
        void SaveMemberLoan(int memberId, int memberLoan);
    }
}
