using System;

namespace Chess.Domain
{
    public class Pawn
    {
        private ChessBoard _chessBoard;
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;
        
        public ChessBoard ChessBoard
        {
            get { return _chessBoard; }
            set { _chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return _pieceColor; }
            private set { _pieceColor = value; }
        }

        public Pawn(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public void Move(MovementType movementType, int newX, int newY)
        {
			if (newX != _xCoordinate) //pawns only move in the Y axis, direction chosen by color, magnitude is always 1 as there is no starting jump rule in this game of 'chess'
				return; // I feel like throwing an exception here, but that aint in the spec.

			if(_pieceColor == PieceColor.Black) //black decreases y to move forward
			{
				if (newY < _yCoordinate && Math.Abs(newY - _yCoordinate) == 1)
					_yCoordinate = newY;
			}
			else // white increases y to move forward
			{
				if (newY > _yCoordinate && Math.Abs(newY - _yCoordinate) == 1)
					_yCoordinate = newY;
			}			 
		}

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
