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

			protected class Given_Empty_ChessBoard : ChessBoardSuccessContext
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
				public void When_IsLegalBoardPosition_0_0_ShouldBe_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(0, 0);
					Assert.That(isLegal, Is.True);
				}

				[Test]
				public void When_IsLegalBoardPosition_5_5_ShouldBe_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(5, 5);
					Assert.That(isLegal, Is.True);
				}

				[Test]
				public void When_IsLegalBoardPosition_11_5_Should_Not_Be_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(11, 5);
					Assert.That(isLegal, Is.False);
				}

				[Test]
				public void When_IsLegalBoardPosition_0_9_Should_Not_Be_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(0, 9);
					Assert.That(isLegal, Is.False);
				}

				[Test]
				public void When_IsLegalBoardPosition_11_0_Should_Not_Be_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(11, 0);
					Assert.That(isLegal, Is.False);
				}

				[Test]
				public void When_IsLegalBoardPosition_negitive1_5_Should_Not_Be_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(-1, 5);
					Assert.That(isLegal, Is.False);
				}

				[Test]
				public void When_IsLegalBoardPosition_5_negitive1_Should_Not_Be_Legal()
				{
					var isLegal = ChessBoard.IsLegalBoardPosition(5, -1);
					Assert.That(isLegal, Is.False);
				}
			}
		}
	}
}
