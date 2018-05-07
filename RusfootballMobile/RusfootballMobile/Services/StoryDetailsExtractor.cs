using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RusfootballMobile.Models;

[assembly: Xamarin.Forms.Dependency(typeof(RusfootballMobile.Services.StoryDetailsExtractor))]
namespace RusfootballMobile.Services
{
    internal class StoryDetailsExtractor : IStoryDetailsExtractor
    {
        public StoryDetailsExtractor()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public async Task<string> GetDetails(IStory story)
        {
            try
            {
                byte[] bytes;
                using (var httpClient = new HttpClient())
                    bytes = await httpClient.GetByteArrayAsync(story.Details);
                var enc = Encoding.GetEncoding(1251);
                var html = enc.GetString(bytes);

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var node = doc.DocumentNode.SelectSingleNode("//div[@class='short-story-news']");

                var head = doc.DocumentNode.SelectSingleNode("//head");
                return "<html>" +
                            "<head>" +
                                "<base href=\"https://www.rusfootball.info/\"></base>" +
                                head.InnerHtml +
                            "</head>" +
                             $"<body>{node.OuterHtml}</body>" +
                       "</html>";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return String.Empty;
            }
        }
    }
}
