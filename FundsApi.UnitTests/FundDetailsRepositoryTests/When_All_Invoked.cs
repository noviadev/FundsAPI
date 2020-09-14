using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundDetailsRepositoryTests
{
    public class When_All_Invoked : Given_A_FundDetailsRepository
    {
        [Test]
        public void Then_Result_Should_Not_Be_Null()
        {
            SUT.All().ShouldNotBeNull();
        }
    }
}
