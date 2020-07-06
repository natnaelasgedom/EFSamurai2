namespace EFSamurai.Domain
{
    public class SamuraiBattle
    {
        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
        public int BattleID { get; set; }
        public Battle Battle { get; set; }
    }
}
