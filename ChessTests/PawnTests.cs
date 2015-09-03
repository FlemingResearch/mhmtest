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
					Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
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

			protected class Given_ChessBoard_WhitePawn_6_1 : PawnSuccessContext
			{
				protected override void Given()
				{
					base.Given();
					PieceColor = PieceColor.White;
					XCoordinate = 6;
					YCoordinate = 1;
					Pawn = new Pawn(PieceColor);

					ChessBoard.Add(Pawn, XCoordinate, YCoordinate, PieceColor);
				}

				[Test]
				public void White_Pawn_Is_Added_To_6_1_Correctly()
				{	
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
				}

				[Test]
				public void When_Making_Illegal_Move_7_2_Pawn_Should_Not_Move()
				{
					Pawn.Move(MovementType.Move, 7, 2);
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
				}

				[Test]
				public void When_Making_Illegal_Move_6_4_Pawn_Should_Not_Move()
				{															  
					Pawn.Move(MovementType.Move, 6, 4);
					Assert.That(Pawn.XCoordinate, Is.EqualTo(6));
					Assert.That(Pawn.YCoordinate, Is.EqualTo(1));
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
	}
}
