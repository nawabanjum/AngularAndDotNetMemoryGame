using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.DomainModels
{
    public class PlayerTurnRequest
    {
        public int PlayerId { get; set; }
        public int Card1Position { get; set; }
        public int Card2Position { get; set; }
    }
}
