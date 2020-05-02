using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWCFService
{
    [DataContract]
    public class GameHelper
    {
        [DataMember]
        public CellType[] Field { get; set; }
        [DataMember]
        private const int fieldSize = 9;
        [DataMember]
        public bool IsGameEnded { get; set; }
        [DataMember]
        public bool PlayersTurn { get; set; } = false;

        public GameHelper()
        {
            Field = new CellType[fieldSize];
            for (int i = 0; i < Field.Length; i++)
            {
                Field[i] = CellType.EMPTY;
            }
        }

        public GameHelper(CellType[] field)
        {
            Field = field;
        }

    }

    [DataContract]
    public enum CellType
    {
        [EnumMember]
        EMPTY,
        [EnumMember]
        HRESTIK,
        [EnumMember]
        NOLIK
    }
}
