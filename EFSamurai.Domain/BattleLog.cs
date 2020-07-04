using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class BattleLog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BattleID { get; set; }
        public Battle Battle { get; set; }
        public ICollection<BattleEvent> MyBattleEvents { get; set; }

    }
}
