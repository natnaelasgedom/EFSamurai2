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
        public ICollection<SamuraiBattle> MySamurais { get; set; }
        public BattleLog MyBattleLog { get; set; }

    }

    public class BattleLog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BattleID { get; set; }
        public Battle Battle { get; set; }

    }

    public class BattleEvent
    {
        public int ID { get; set; }
        public int Order { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

    }
}
