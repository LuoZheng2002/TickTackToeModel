using Contracts.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TickTackToe
{
	public enum Stone
	{
		Empty,
		Black,
		White
	}
	public class TickTackToeMove : MoveBase
	{
		public Stone Stone { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
        public TickTackToeMove(Stone stone, int x, int y)
        {
			Stone = stone;
			X = x;
			Y = y;
        }
    }
	public class TickTackToeModel: GameModelBase
	{
		public Stone[,] Chessboard { get; set; } = new Stone[3, 3];
		public Stone WhoseTurn { get; set; }
		public Stone WhoIsAI { get; set;}
		public static Stone EnemyOf(Stone stone)
		{
			if (stone == Stone.Black)
			{
				return Stone.White;
			}
			else if(stone == Stone.White)
			{
				return Stone.Black;
			}
			return Stone.Empty;
		}
		public override bool ValidMove(MoveBase move)
		{
			TickTackToeMove tickTackToeMove = (TickTackToeMove)move;
			if (Chessboard[tickTackToeMove.Y, tickTackToeMove.X] == Stone.Empty)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public override void DoMove(MoveBase move)
		{
			TickTackToeMove tickTackToeMove = (TickTackToeMove)move;
			Chessboard[tickTackToeMove.Y, tickTackToeMove.X] = tickTackToeMove.Stone;
			WhoseTurn = TickTackToeModel.EnemyOf(WhoseTurn);
		}
		public override GameModelBase Copy()
		{
			TickTackToeModel model = new TickTackToeModel();
			model.WhoseTurn = WhoseTurn;
			model.WhoIsAI = WhoIsAI;
			for(int i = 0;i < 3;i++)
			{
				for(int j = 0;j < 3;j++)
				{
					model.Chessboard[i,j] = Chessboard[i,j];
				}
			}
			return model;
		}
        public TickTackToeModel()
        {
			WhoseTurn = Stone.Black;
        }
    }
}
