using System;
using System.Collections;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Class1
    {
    }

    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Quote> myQuotes { get; set; }
    }

    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Quality? QualityOfQuote { get; set; }

        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
    }
}
