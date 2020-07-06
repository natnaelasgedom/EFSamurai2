using System;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Quote> MyQuotes { get; set; }
        public Hairstyle? HairStyle { get; set; }
        public SecretIdentity MySecretIdentity { get; set; }
        public ICollection<SamuraiBattle> MyBattles { get; set; }

    }
}
