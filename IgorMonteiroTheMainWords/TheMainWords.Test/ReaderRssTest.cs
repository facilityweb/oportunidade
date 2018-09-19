using System;
using IgorMonteiroTheMainWords.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IgorMonteiroTheMainWords.ValueObjects;

namespace TheMainWords.Test
{
    [TestClass]
    public class ReaderRssTest
    {
        [TestMethod]
        public void CallRssWebMethodTest()
        {
            RSSReader reader = new RSSReader();
            reader.GetLastTenPosts();
            Assert.AreNotEqual(0, reader.GetLastTenPosts().Count);
        }

        [TestMethod]
        public void RemoveHtmlAttributesTest()
        {
            RSSReader reader = new RSSReader();
            var posts = reader.GetLastTenPosts();
            foreach (var item in posts)
            {
                if (item.Title.Contains("<") || item.Title.Contains("/>"))
                {
                    Assert.Fail("The html was not removed from Title.");
                }
                if (item.Description.Contains("<") || item.Description.Contains("/>"))
                {
                    Assert.Fail("The html was not removed from Description.");
                }
                if (item.Content.Contains("<") || item.Content.Contains("/>"))
                {
                    Assert.Fail("The html was not removed from Description.");
                }
            }
        }

        [TestMethod]
        public void RemoveAccentsTest()
        {
            var accentText = "Téste com Válôres ácentúádos".ReplaceAccents();
            Assert.AreEqual("Teste com Valores acentuados", accentText);
        }
        [TestMethod]
        public void RemoveSpecialCharsTest()
        {
            var accentText = "Teste %&*)(*&%&$%@#$%".RemoveSpecialChars();
            Assert.AreEqual("Teste", accentText.Trim());
        }
        [TestMethod]
        public void RemovePrepositionsTest()
        {
            var accentText = "Todas as peças que fazem parte de um automóvel".RemovePrepositions();
            Assert.AreEqual(5, accentText.Count);
        }
        [TestMethod]
        public void GetTopTenWordsInRssTopicTest()
        {
            RSSReader reader = new RSSReader();
            var posts = reader.GetLastTenPosts();
            var mostTopics = reader.GetTopTenWordsInRssTopic(posts);
            Assert.AreNotEqual(0, mostTopics.Count);
        }
        [TestMethod]
        public void CountGroupedWordsFromTextTest()
        {
            var reader = new RSSReader();
            var words = "teste teste teste teste TESTE Teste teste abacaxi teste morango";
            var wordsGrouped = reader.GetTopTenWordsInRssTopic(new List<RSSItem>() { new RSSItem() { Description = words, Title="abacaxi" , Content ="morango"} });
            Assert.AreEqual(8, wordsGrouped[0].Quantity);
            Assert.AreEqual("teste", wordsGrouped[0].Word);
        }
    }
}
