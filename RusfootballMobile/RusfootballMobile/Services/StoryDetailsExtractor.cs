using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RusfootballMobile.Logging;
using RusfootballMobile.Models;

[assembly: Xamarin.Forms.Dependency(typeof(RusfootballMobile.Services.StoryDetailsExtractor))]
namespace RusfootballMobile.Services
{
    internal class StoryDetailsExtractor : IStoryDetailsExtractor
    {
        private readonly ILogger _logger = LoggerFactory.GetLogger<StoryDetailsExtractor>();
        private readonly Encoding _enc1251 = Encoding.GetEncoding(1251);

        public async Task<string> GetDetails(IStory story)
        {
            try
            {
                byte[] bytes;
                using (var httpClient = new HttpClient())
                    bytes = await httpClient.GetByteArrayAsync(story.Details);
                var html = _enc1251.GetString(bytes);

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var node = doc.DocumentNode.SelectSingleNode("//div[@class='short-story-news']");

                return "<html>" +
                            "<head>" +
                                "<base href=\"https://www.rusfootball.info/\"></base>" +
                            "</head>" +
                             $"<body>{node.InnerHtml}</body>" +
                       "</html>";
            }
            catch (Exception e)
            {
                _logger.Error("Details error", e);
                return String.Empty;
            }
        }
    }
}
