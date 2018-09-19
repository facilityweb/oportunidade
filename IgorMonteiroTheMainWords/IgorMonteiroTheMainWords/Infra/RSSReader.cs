using IgorMonteiroTheMainWords.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace IgorMonteiroTheMainWords.Infra
{
    public class RSSReader
    {
        public IList<RSSItem> GetLastTenPosts()
        {
            string urlFeed = "https://www.minutoseguros.com.br/blog/feed/";
            XDocument xml = XDocument.Load(urlFeed);

            XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";

            return (from x in xml.Descendants("item")
                    select new RSSItem
                    {
                        Title = StripHTML(((string)x.Element("title"))),
                        Description = StripHTML(((string)x.Element("description"))),
                        Content = StripHTML(((string)x.Element(nsContent + "encoded"))),
                    }).ToList();
        }
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        public IList<WordCounter> GetTopTenWordsInRssTopic(IList<RSSItem> posts)
        {
            IList<string> words = new List<string>();

            foreach (var item in posts)
            {
                words = words.Union(item.Title.ReplaceAccents().RemoveSpecialChars().RemovePrepositions()).ToList();
                words = words.Union(item.Description.ReplaceAccents().RemoveSpecialChars().RemovePrepositions()).ToList();
                words = words.Union(item.Content.ReplaceAccents().RemoveSpecialChars().RemovePrepositions()).ToList();
            }

            return words.Select(c => c.ToLowerInvariant())
                                   .GroupBy(c => c)
                                   .Select(g => new WordCounter
                                   {
                                       Word = g.Key,
                                       Quantity = g.Count()
                                   })
                                   .OrderByDescending(g => g.Quantity).Take(10).ToList();
        }
    }
}
