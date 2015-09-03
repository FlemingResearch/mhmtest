using System;
using Chess.Domain;
using NUnit.Framework;					

namespace ChessTests
{
	internal class PawnTests : BaseTestContext
	{
		protected class PawnTestContext : PawnTests
		{
			protected Exception Exception;
			protected ChessBoard ChessBoard;
			protected PieceColor PieceColor;

			protected Pawn Pawn;

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

			protected class PawnSuccessContext : PawnTestContext
			{
				protected int XCoordinate = 6;
				protected int YCoordinate = 3;

				protected override void Given()
				{
					PieceColor = PieceColor.Black;
					Pawn = new Pawn(PieceColor);
					base.Given();
				} 

				[Test]
				public void When_AddingPawn()
				{
					ChessBoard.Add(Pawn, XCoordinate, YCoordinate, PieceColor);
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(3));
				}

				[Test]
				public void Exception_ShouldBe_Null()
				{
					Assert.That(Exception, Is.Null);
				}
			}

			protected class Given_ChessBoard_BlackPawn_6_3 : PawnSuccessContext
			{
				protected override void Given()
				{
					base.Given();
					PieceColor = PieceColor.Black;
					XCoordinate = 6;
					YCoordinate = 3;
					Pawn = new Pawn(PieceColor);

					ChessBoard.Add(Pawn, XCoordinate, YCoordinate, PieceColor);
				} 

				[Test]
				public void When_Making_Illegal_Move_7_3_Pawn_Should_Not_Move()
				{	
					Pawn.Move(MovementType.Move, 7, 3);
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(3));
				}

				[Test]
				public void When_Making_Illegal_Move_4_3_Pawn_Should_Not_Move()
				{
					Pawn.Move(MovementType.Move, 4, 3);
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(3));
				}

				[Test]
				public void When_Making_Legal_Move_6_2_Pawn_Should_Move()
				{
					Pawn.Move(MovementType.Move, 6, 2);
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(2));
				}
			}
		}

		[TestFixture]
		public class When_using_a_blackPawn_and
		{
			private ChessBoard _chessBoard;
			private Pawn Pawn;

			[SetUp]
			public void SetUp()
			{
				_chessBoard = new ChessBoard();
				Pawn = new Pawn(PieceColor.Black);
			}

			

			

		}

		[TestFixture]
		public class When_using_a_whitePawn_and
		{
			private ChessBoard _chessBoard;
			private Pawn Pawn;

			[SetUp]
			public void SetUp()
			{
				_chessBoard = new ChessBoard();
				Pawn = new Pawn(PieceColor.White);
			}

			[Test]
			public void
				_01_placing_the_whitePawn_on_X_equals_6_and_Y_equals_1_should_place_the_whitePawn_on_that_place_on_the_board()
			{
				_chessBoard.Add(Pawn, 6, 1, PieceColor.White);
				Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
				Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
			}

			[Test]
			public void
				_10_making_an_illegal_move_by_placing_the_whitePawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_7_and_Y_eqauls_2_should_not_move_thePawn
				()
			{
				_chessBoard.Add(Pawn, 6, 1, PieceColor.White);
				Pawn.Move(MovementType.Move, 7, 2);
				Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
				Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
			}

			[Test]
			public void
				_11_making_an_illegal_move_by_placing_the_whitePawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_6_and_Y_eqauls_4_should_not_move_thePawn
				()
			{
				_chessBoard.Add(Pawn, 6, 1, PieceColor.White);
				Pawn.Move(MovementType.Move, 6, 4);
				Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
				Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
			}

			[Test]
			public void
				_20_making_a_legal_move_by_placing_the_whitePawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_6_and_Y_eqauls_2_should_move_thePawn
				()
			{
				_chessBoard.Add(Pawn, 6, 1, PieceColor.White);
				Pawn.Move(MovementType.Move, 6, 2);
				Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
				Assert.That(Pawn.YCoordinate, Is.EqualTo(2));
			}

		}
	}
}
