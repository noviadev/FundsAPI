using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundsApi.UnitTests
{
    public abstract class BaseUnitTests<T>
    {
        protected T SUT;

        [SetUp]
        public void Setup()
        {
            SetContext();
            Because();
        }

        public virtual void Because()
        {

        }

        public abstract void SetContext();
    }
}
