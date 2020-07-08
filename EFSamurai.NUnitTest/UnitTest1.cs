using System.Linq;
using NUnit.Framework;
using EFSamurai.Domain;
using EFSamurai.Data;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.NUnitTest
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            using (var context = new SamuraiContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }

        [SetUp]
        public void Init()
        {
        }
        
        [Test]
        public void AddOneSamuraiTwice()
        {
            EfMethods.AddOneSamurai("Zelda");
            EfMethods.AddOneSamurai("Link");
            string[] result = EfMethods.ListAllSamuraiNames().ToArray();
            CollectionAssert.AreEqual(new string[] {"Zelda", "Link"}, result);
        }

        [Test]
        public void Test_AddOneSamuraiWithSecretIdentity()
        {
            var samurai = new Samurai() 
            {
                Name = "Ganondorf Dragmire",
                HairStyle = Hairstyle.Western,
            };
            int samuraiId = EfMethods.AddOneSamurai(samurai);
            EfMethods.UpdateSamuraiSetSecretIdentity(samuraiId, "Ganon");
            Samurai actualSamurai = EfMethods.GetSamurai(samuraiId);
            Assert.AreEqual("Ganondorf Dragmire", actualSamurai.Name);
            Assert.AreEqual(Hairstyle.Western, actualSamurai.HairStyle);
            Assert.AreEqual("Ganon", actualSamurai.MySecretIdentity.RealName);
        }


    }
}