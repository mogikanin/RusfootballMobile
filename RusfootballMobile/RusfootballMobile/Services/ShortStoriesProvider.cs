using System;
using System.Collections.Generic;
using System.Web;
using HtmlAgilityPack;
using RusfootballMobile.Models;

namespace RusfootballMobile.Services
{
    public class ShortStoriesProvider : DataProviderBase<ShortStory>
    {
        public ShortStoriesProvider()
            :base("https://www.rusfootball.info")
        {
        }

        protected override IEnumerable<ShortStory> ParseItems(HtmlDocument doc)
        {
            var contentNode = doc.DocumentNode.SelectSingleNode("//div[@id='dle-content']");
            if (contentNode == null)
            {
                throw new Exception("Short stories collection not found!");
            }

            var items = contentNode.SelectNodes("//div[@class='short-story']");
            foreach (var story in items)
            {
                var shortStory = new ShortStory();
                var innerDoc = new HtmlDocument();
                innerDoc.LoadHtml(story.InnerHtml);

                var innerStory = innerDoc.DocumentNode;
                var ahref = innerStory.SelectSingleNode("//h2/a");
                shortStory.Title = HttpUtility.HtmlDecode(ahref.InnerHtml);
                shortStory.Details = new Uri(ahref.Attributes["href"].Value);
                var news = innerStory.SelectSingleNode("//div[@class='short-story-news']");
                shortStory.Image = new Uri(Host + news.SelectSingleNode("//img").Attributes["src"].Value);
                shortStory.Text = news.InnerText.Trim();
                var info = innerStory.SelectSingleNode("//div[@class='short-story-info']");
                var date = HttpUtility.HtmlDecode(info.SelectSingleNode("//div[@class='short-story-date2']/a").InnerHtml);
                shortStory.Date = date;
                yield return shortStory;
            }
        }
    }
}