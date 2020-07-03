namespace EFSamurai.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Quality? QuoteStyle { get; set; }

        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
    }
}
