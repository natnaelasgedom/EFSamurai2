using EFSamurai.Data;
using EFSamurai.Domain;
using System;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Natnael Asgedom");
        }

        private static void AddOneSamurai()
        {
            var samurai = new Samurai() { Name = "Miyamoto Musashi" };
            using(var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}
