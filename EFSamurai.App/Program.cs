using EFSamurai.Data;
using EFSamurai.Domain;
using System;
using System.Collections.Generic;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            AddOneSamurai();
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

        private static void AddSomeSamurais()
        {
            ICollection<Samurai> newSamurais = new List<Samurai>() { 
                new Samurai() { Name = "Sasaki Kojiro"},
                new Samurai() { Name = "Oda Nobunaga" },
                new Samurai() { Name = "Toyotomi Hideyoshi" } 
            };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(newSamurais);
                context.SaveChanges();
            }
        }

        private static void AddSomeBattles()
        {
            ICollection<Battle> battleList = new List<Battle>()
            {
                new Battle()
                {
                    Name = "Battle 1",
                    Description = "Description Battle 1",
                    IsBrutal = true,
                    StartDate = new DateTime(1589,6,2),
                    EndDate = new DateTime(1590,1,1),
                    MyBattleLog = new BattleLog()
                    {
                        MyBattleEvents = new List<BattleEvent>
                        {
                            new BattleEvent()
                            {
                                Description = "Eventdescription 1.1",
                                Summary = "Summary 1.1",
                                Order = 1
                            },
                            new BattleEvent()
                            {
                                Description = "Eventdescription 1.2",
                                Summary = "Summary 1.2",
                                Order = 2
                            },
                            new BattleEvent()
                            {
                                Description = "Eventdescription 1.3",
                                Summary = "Summary 1.3",
                                Order = 3
                            }
                        }
                    }
                },
                new Battle()
                {
                    Name = "Battle 2",
                    Description = "Description Battle 2",
                    IsBrutal = true,
                    StartDate = new DateTime(1595,6,2),
                    EndDate = new DateTime(1598,1,1),
                    MyBattleLog = new BattleLog()
                    {
                        MyBattleEvents = new List<BattleEvent>
                        {
                            new BattleEvent()
                            {
                                Description = "Eventdescription 2.1",
                                Summary = "Summary 2.1",
                                Order = 1
                            },
                            new BattleEvent()
                            {
                                Description = "Eventdescription 2.2",
                                Summary = "Summary 2.2",
                                Order = 2
                            },
                            new BattleEvent()
                            {
                                Description = "Eventdescription 2.3",
                                Summary = "Summary 2.3",
                                Order = 3
                            }
                        }
                    }
                },
                new Battle()
                {
                    Name = "Battle 3",
                    Description = "Description Battle 3",
                    IsBrutal = true,
                    StartDate = new DateTime(1599,6,2),
                    EndDate = new DateTime(1600,1,1),
                    MyBattleLog = new BattleLog()
                    {
                        MyBattleEvents = new List<BattleEvent>
                        {
                            new BattleEvent()
                            {
                                Description = "Eventdescription 3.1",
                                Summary = "Summary 3.1",
                                Order = 1
                            },
                            new BattleEvent()
                            {
                                Description = "Eventdescription 3.2",
                                Summary = "Summary 3.2",
                                Order = 2
                            },
                            new BattleEvent()
                            {
                                Description = "Eventdescription 3.3",
                                Summary = "Summary 3.3",
                                Order = 3
                            }
                        }
                    }
                },
            };

            using (var context = new SamuraiContext())
            {
                context.Battles.AddRange(battleList);
                context.SaveChanges();
            }
        }

        private static void AddOneSamuraiWithRelatedData()
        {
            var samurai = new Samurai
            {
                Name = "Uzumaki Naruto",
                MyQuotes = new List<Quote>
                {
                    new Quote{ Text = "Live and die with honor.", QuoteStyle = Quality.Awesome},
                    new Quote{ Text = "This too shall pass.", QuoteStyle = Quality.Cheesy}
                }, 
                HairStyle = Hairstyle.Western,
                MySecretIdentity = new SecretIdentity
                {
                    RealName = "Uchiha Sasuke"
                }
            };
        }

        private static void ClearDatabase()
        {

        }
    }
}
