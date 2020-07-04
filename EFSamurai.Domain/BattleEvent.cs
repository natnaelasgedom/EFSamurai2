namespace EFSamurai.Domain
{
    public class BattleEvent
    {
        public int ID { get; set; }
        public int Order { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int BattleLogID { get; set; }
        public BattleLog BattleLog { get; set; }


    }
}
