using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //    AddOneSamurai();
            //    AddSomeSamurais();
            //    AddSomeBattles();
            //    AddOneSamuraiWithRelatedData();
            //ClearDatabase();
            WriteOutList(GetBattlesForSamurai("Uzumaki Naruto"));

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
                }
            };

            using (var context = new SamuraiContext())
            {
                context.Battles.AddRange(battleList);
                context.SaveChanges();
            }
        }

        private static void AddOneSamuraiWithRelatedData()
        {
            using var context = new SamuraiContext();
            var samurai = new Samurai
            {
                Name = "Uzumaki Naruto",
                MyQuotes = new List<Quote>
                {
                    new Quote { Text = "Live and die with honor", QuoteStyle = Quality.Awesome },
                    new Quote { Text = "This too shall pass", QuoteStyle = Quality.Awesome }
                },
                HairStyle = Hairstyle.Western,
                MySecretIdentity = new SecretIdentity
                {
                    RealName = "Uchiha Sasuke"
                },
                SamuraiBattles = new List<SamuraiBattle>()
                {
                    new SamuraiBattle
                    {

                       BattleID = context.Battles.First().ID
                    }
                }
            };

            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void ClearDatabase()
        {
            
            using var context = new SamuraiContext();
            context.RemoveRange(context.Samurais);
            context.RemoveRange(context.Battles);
            context.SaveChanges();

        }

        private static ICollection<string> ListAllSamuraiNames()
        {
            using var context = new SamuraiContext();
            return context.Samurais.Select(s => s.Name).ToList();
        }

        private static ICollection<string> ListAllSamuraiNames_OrderByNames()
        {
            using var context = new SamuraiContext();
            return context.Samurais.OrderBy(s => s.Name).Select(p => p.Name).ToList();
        }

        private static ICollection<string> ListAllSamuraiNames_OrderByIdDescending()
        {
            using var context = new SamuraiContext();
            return context.Samurais.OrderByDescending(s => s.Id).Select(s => s.Name).ToList();
        }

        private static string FindSamuraiWithRealName(string name)
        {
            using var context = new SamuraiContext();
            if (context.Samurais.Any(s => s.MySecretIdentity.RealName == name))
            {
                return $"Found the samurai with the name {name} and his covername is " +
                    $"{context.Samurais.Where(s => s.MySecretIdentity.RealName == name).Select(s => s.Name).ToList()[0]}";
            } 
            return $"Could not find any samurai with the real name {name}";
        }

        private static ICollection<string> ListAllQuotesOfType(Quality quoteStyle)
        {
            using var context = new SamuraiContext();
            var output = context.Quotes.Where(q => quoteStyle == q.QuoteStyle).Select(q => q.Text).ToList();
            return output;
        }
        private static ICollection<string> ListAllQuotesOfType_WithSamurai(Quality quoteStyle)
        {
            var output = new List<string>();
            using var context = new SamuraiContext();
            foreach (var quote in context.Quotes.Where(q => quoteStyle == q.QuoteStyle).Include(q => q.Samurai))
            {
                output.Add($"{quote.Text} is a {quoteStyle} quote by {quote.Samurai.Name}.");
            }
            return output;
        }

        private static ICollection<string> ListAllBattles(DateTime from, DateTime to, bool? isBrutal)
        {
            var output = new List<string>();
            using var context = new SamuraiContext();
            var battles = context.Battles.Where(b => DateTime.Compare(b.StartDate, from) > 0 && DateTime.Compare(b.EndDate, to) < 0);
            foreach (var battle in battles)
            {
                if (isBrutal == null || battle.IsBrutal == isBrutal)
                {
                    output.Add($"{battle.Name} {(battle.IsBrutal ? "is" : "is not")} a brutal battle within the period.");
                }
            }
            return output;
        }

        private static ICollection<string> AllSamuraiNamesWithAliases()
        {
            var output = new List<string>();
            using (var context = new SamuraiContext())
            {
                var samurais_with_aliases = context.Samurais.Where(s => s.MySecretIdentity.RealName != null)
                    .Include(s => s.MySecretIdentity);
                foreach (var samurai in samurais_with_aliases)
                {
                    output.Add($"{samurai.Name} alias {samurai.MySecretIdentity.RealName}");
                }
            }
            return output;
        }

        private static void WriteOutList(ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static ICollection<string> ListAllBattles_WithLog(DateTime from, DateTime to, bool isBrutal)
        {
            ICollection<string> output = new List<string>();
            output.Add("-----------------------------------------------------------------");
            using (var context = new SamuraiContext())
            {
                var joinedTables = context.Battles
                    .Where(b => b.StartDate >= from && b.EndDate <= to && b.IsBrutal == isBrutal)
                    .Include(b => b.MyBattleLog)
                    .ThenInclude(bl => bl.MyBattleEvents);
                foreach (var battle in joinedTables)
                {
                    string s = $"| {"Name of battle",-15} | {battle.Name,-15} \n" +
                               $"| {"Log name",-15} | {battle.MyBattleLog.Name ?? "No name",-15} \n";
                    foreach (var battleEvent in battle.MyBattleLog.MyBattleEvents)
                    {
                        s += $"| {"Event",-15} | {battleEvent.Summary} (Order: {battleEvent.Order}, Battle: {battle.Name}) \n";
                    }
                    output.Add(s);
                    output.Add("-----------------------------------------------------------------");
                }
            }
            return output;
        }

        private static ICollection<SamuraiInfo> GetSamuraiInfo()
        {
            var samuraiInfoList = new List<SamuraiInfo>();
            using (var context = new SamuraiContext())
            {
                var samurais_withSecretID_withBattles = context.Samurais
                    .Include(s => s.MySecretIdentity)
                    .Include(s => s.SamuraiBattles)
                    .ThenInclude(sb => sb.Battle);
                foreach (var samurai in samurais_withSecretID_withBattles)
                {
                    string battlenames = "";
                    
                    foreach (var sb in samurai.SamuraiBattles)
                    {
                        battlenames += $"{sb.Battle.Name},";
                    }

                    string realName = samurai.MySecretIdentity == null
                        ? "Has no alias"
                        : samurai.MySecretIdentity.RealName;

                    samuraiInfoList.Add(new SamuraiInfo()
                    {
                        BattleNames = battlenames, 
                        RealName = realName,
                        Name = samurai.Name
                    });
                }
            }
            return samuraiInfoList;
        }

        private static void WriteOutList(ICollection<SamuraiInfo> collection)
        {
            Console.WriteLine($"{"Name", -20} {"RealName",-20} {"Battles", -20}");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var si in collection)
            {
                Console.WriteLine($"{si.Name,-20} {si.RealName,-20} {si.BattleNames,-20}");
            }
        }

        private static ICollection<string> GetBattlesForSamurai(string samuraiName)
        {
            ICollection<string> output = new List<string>();
            using (var context = new SamuraiContext())
            {
                var samurais_with_battles = context.Samurais
                    .Where(s => s.Name == samuraiName)
                    .Include(s => s.SamuraiBattles)
                    .ThenInclude(sb => sb.Battle);
                foreach (var samurai in samurais_with_battles)
                {
                    string s = $"Samurai {samurai.Name} har participated in the following battles: \n" +
                               $"{"ID", -20} {"Name", -20}\n";
                    foreach (var sb in samurai.SamuraiBattles)
                    {
                        s += $"{sb.BattleID, -20} {sb.Battle.Name, -20}\n";
                    }
                    output.Add(s);
                }
            }
            return output;
        }

    }
}
