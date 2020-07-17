using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting.Basics.Tests
{
    public class BasicTest
    {
        [Fact]
        public void PassCheck()
        {
            Assert.True(true);
        }

        [Fact]
        public void FailCheck()
        {
            Assert.True(false);
        }
    }
}
