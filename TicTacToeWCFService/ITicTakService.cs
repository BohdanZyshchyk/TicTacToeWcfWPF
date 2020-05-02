using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToeWCFService
{
    [ServiceContract(CallbackContract = typeof(ITicTakCallBack))]
    public interface ITicTakService
    {
        [OperationContract]
        GameHelper GetGameHelper();
        [OperationContract]
        void setGameHelper(GameHelper Game);
        [OperationContract]
        bool Connect();
        [OperationContract]
        void MakeTurn(int cellNumb, CellType symb);


    }

    [ServiceContract]
    public interface ITicTakCallBack
    {
        [OperationContract]
        void GetGame(CellType game);
    }

    
}
