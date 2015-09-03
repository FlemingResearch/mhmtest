using System;
using NUnit.Framework;

namespace ChessTests
{
	[SetUpFixture]
	internal class BaseTestContext
	{	
		protected virtual void Given() { }

		[SetUp]
		protected virtual void When()
		{
			this.Given();
		}
	}
}
