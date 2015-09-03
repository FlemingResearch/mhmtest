using System;
using Chess.Domain;
using NUnit.Framework;

namespace ChessTests
{
	internal class ChessBoardTests : BaseTestContext
	{
		protected class ChessBoardTestContext : BaseTestContext
		{
			protected Exception Exception;
			protected ChessBoard ChessBoard;

			protected override void Given()
			{
				ChessBoard = new ChessBoard();
				base.Given();
			}

			protected override void When()
			{
				try
				{
					base.When();
				}
				catch (Exception ex)
				{
					Exception = ex;
				}
			}

			protected class ChessBoardSuccessContext : ChessBoardTestContext
			{
				protected override void Given()
				{
					base.Given();
				}

				protected override void When()
				{
					base.When();
				}

				[Test]
				public void MaxBoardWidth_ShouldBe_7()
				{
					Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(7));
				}

				[Test]
				public void MaxBoardHeight_ShouldBe_7()
				{
					Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(7));
				}

				[Test]
				public void Exception_ShouldBe_Null()
				{
					Assert.That(Exception, Is.Null);
				}
			}

			
		}
	}
}
