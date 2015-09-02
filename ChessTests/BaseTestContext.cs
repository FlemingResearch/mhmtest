using System;
using NUnit.Framework;

namespace ChessTests
{
	[SetUpFixture]
	internal class BaseTestContext
	{
		protected Exception Exception;
		
		protected virtual void Given() { }

		[SetUp]
		protected virtual void When()
		{
			try
			{
				this.Given();
			}
			catch (Exception ex)
			{
				Exception = ex;	
			}				   
		}
	}
}
