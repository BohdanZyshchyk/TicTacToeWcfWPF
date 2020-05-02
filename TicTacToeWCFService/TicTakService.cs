using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToeWCFService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class TicTakService : ITicTakService
    {
        public List<ITicTakCallBack>  ticTakCall = new List<ITicTakCallBack>();

        public GameHelper Game { get; set; }

        public TicTakService()
        {
            Game = new GameHelper();
        }
        public GameHelper GetGameHelper()
        {
            return Game;
        }

        public bool Connect()
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<ITicTakCallBack>();
                if (!ticTakCall.Contains(callback))
                    ticTakCall.Add(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void setGameHelper(GameHelper game)
        {
            Game = game;
        }

       

        public void MakeTurn(int cellNumb, CellType symb)
        {
            //Game.Field[cellNumb] = symb;
            foreach (var item in ticTakCall)
            {
                item.GetGame(symb);
            }
        }
    }

   
}
