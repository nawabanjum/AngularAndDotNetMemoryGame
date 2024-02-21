using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.DomainModels
{
    public class GameState
    {
        public List<Card> Cards { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int CurrentPlayer { get; set;}
    }
}
