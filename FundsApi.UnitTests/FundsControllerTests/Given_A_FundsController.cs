using System;
using System.Collections.Generic;
using System.Text;
using Api.Controllers;
using FundsApi.Core.Controllers;

namespace FundsApi.UnitTests.FundsControllerTests
{
    public class Given_A_FundsController : BaseUnitTests<IFundsController>
    {
        public override void SetContext()
        {
            SUT = new FundsController();
        }
    }
}
