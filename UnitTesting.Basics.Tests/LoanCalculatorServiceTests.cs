using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace UnitTesting.Basics.Tests
{
    public class LoanCalculatorServiceTests
    {
        [Fact]
        public void Run_WithValidInput_WorksCorrectly()
        {
            // Data
            var memberDetailsData =
                JsonConvert.DeserializeObject<MemberDetails[]>(System.IO.File.ReadAllText(@"./Data/members.json"));
            var memberContributions = JsonConvert.DeserializeObject<MemberContributions[]>(
                System.IO.File.ReadAllText(@"./Data/contributions.json"));

            // Arrange
            var loansCalculator = new LoanCalculator();
            var loansRepositoryMock = new Mock<ILoansRepository>();
            loansRepositoryMock.Setup(x => x.GetMemberDetails(It.IsAny<int[]>()))
                .Returns(() => memberDetailsData);
            loansRepositoryMock.Setup(x => x.GetMemberContributions(It.IsAny<int>()))
                .Returns(() => memberContributions[0]);

            var memberIds = memberDetailsData.Select(x => x.Id).ToArray();

            // Act
            var sut = new LoanCalculatorService(loansRepositoryMock.Object, loansCalculator);
            sut.Run(memberIds);

            // Assert
            // 1. Repository calls
            loansRepositoryMock.Verify(x =>
                x.GetMemberDetails(memberIds), Times.AtMostOnce);
            loansRepositoryMock.Verify(x => x.GetMemberContributions(It.Is<int>(x => x == memberIds[0])));
            loansRepositoryMock.Verify(x => x.SaveMemberLoan(
                It.Is<int>( x => x == memberIds[0]),
                        It.Is<int>(x => x == 85000)));
        }
    }
}
