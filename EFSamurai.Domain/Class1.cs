using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;

namespace EFSamurai.Domain
{
    public class Class1
    {
    }

    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Quote> MyQuotes { get; set; }
        public Hairstyle? HairStyle { get; set; }
        public SecretIdentity MySecretIdentity { get; set; }
    }
    
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Quality? QuoteStyle { get; set; }

        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
    }

    public class SecretIdentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
    }
}
