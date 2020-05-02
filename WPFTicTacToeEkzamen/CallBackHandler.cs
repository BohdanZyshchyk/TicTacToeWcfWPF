using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTicTacToeEkzamen.ServiceReference1;

namespace WPFTicTacToeEkzamen
{
    public class CallBackHandler : ITicTakServiceCallback
    {
        public GameHelper Game { get; set; } = new GameHelper();
        //public void GetGame(GameHelper game)
        //{
        //    Game = game;
        //}

        public void GetGame(CellType game)
        {
            switch (game)
            {
                case CellType.EMPTY:
                    break;
                case CellType.HRESTIK:
                    MessageBox.Show("X");
                    break;
                case CellType.NOLIK:
                    MessageBox.Show("0");
                    break;
                default:
                    break;
            }
        }
    }
}
