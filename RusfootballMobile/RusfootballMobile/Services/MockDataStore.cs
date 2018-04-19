using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using RusfootballMobile.Models;

[assembly: Xamarin.Forms.Dependency(typeof(RusfootballMobile.Services.MockDataStore))]
namespace RusfootballMobile.Services
{
    public class MockDataStore : IDataStore<ShortStory>
    {
        private const string HOST = "https://www.rusfootball.info";
        private List<ShortStory> _items;
        private int _page = 1;

        public MockDataStore()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public async Task<IEnumerable<ShortStory>> GetItemsAsync(bool forceRefresh, bool nextPage)
        {
            if (!forceRefresh && _items != null && !nextPage)
                return _items;

            string html = null;
            try
            {
                var host = HOST;
                if (nextPage && _items != null)
                {
                    _page++;
                    host += $"/page/{_page}/";
                }
                else
                {
                    _page = 1;
                }

                byte[] bytes;
                using (var httpClient = new HttpClient())
                    bytes = await httpClient.GetByteArrayAsync(host);
                var enc = Encoding.GetEncoding(1251);
                html = enc.GetString(bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (string.IsNullOrEmpty(html))
            {
                return Enumerable.Empty<ShortStory>();
            }

            // Parse
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var contentNode = doc.DocumentNode.SelectSingleNode("//div[@id='dle-content']");
                if (contentNode == null)
                {
                    throw new Exception("Short stories collection not found!");
                }

                var stories = contentNode.SelectNodes("//div[@class='short-story']");
                var output = new List<ShortStory>(stories.Count);
                var counter = _items?.Count ?? 0;
                foreach (var story in stories)
                {
                    var shortStory = new ShortStory();
                    var innerDoc = new HtmlDocument();
                    innerDoc.LoadHtml(story.InnerHtml);

                    var innerStory = innerDoc.DocumentNode;
                    var ahref = innerStory.SelectSingleNode("//h2/a");
                    shortStory.Title = HttpUtility.HtmlDecode(ahref.InnerHtml);
                    shortStory.Details = new Uri(ahref.Attributes["href"].Value);
                    var news = innerStory.SelectSingleNode("//div[@class='short-story-news']");
                    shortStory.Image = new Uri(HOST + news.SelectSingleNode("//img").Attributes["src"].Value);
                    shortStory.Text = news.InnerText.Trim();
                    var info = innerStory.SelectSingleNode("//div[@class='short-story-info']");
                    var date = HttpUtility.HtmlDecode(info.SelectSingleNode("//div[@class='short-story-date2']/a").InnerHtml);
                    shortStory.Date = date;
                    shortStory.Id = counter++;

                    output.Add(shortStory);
                }

                if (nextPage && _items != null)
                {
                    _items.AddRange(output);
                }
                else
                {
                    _items = output;
                }

                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Enumerable.Empty<ShortStory>();
            }
        }
    }
}