using System;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Battle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBrutal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }
        public BattleLog MyBattleLog { get; set; }

    }
}
