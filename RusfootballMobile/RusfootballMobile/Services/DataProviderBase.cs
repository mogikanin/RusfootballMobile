using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RusfootballMobile.Logging;

namespace RusfootballMobile.Services
{
    public abstract class DataProviderBase<T> : IDataProvider<T>
    {
        private int _page = 1;
        private readonly ILogger _logger;

        protected DataProviderBase(string host)
        {
            Host = host;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _logger = LoggerFactory.GetLogger(GetType());
        }

        protected string Host { get; }
        protected List<T> Items { get; private set; }
        protected abstract List<T> ParseItems(HtmlDocument document);

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh, bool nextPage)
        {
            if (!forceRefresh && Items != null && !nextPage)
                return Items;

            string html = null;
            try
            {
                var host = Host;
                if (nextPage && Items != null)
                {
                    _page++;
                    host += $"/page/{_page}/";
                }
                else
                {
                    _page = 1;
                }

                byte[] bytes;
                _logger.Info($"Loading page: {_page}");
                using (var httpClient = new HttpClient())
                    bytes = await httpClient.GetByteArrayAsync(host);
                var enc = Encoding.GetEncoding(1251);
                html = enc.GetString(bytes);
            }
            catch (Exception e)
            {
                _logger.Error("Load error", e);
            }

            if (string.IsNullOrEmpty(html))
            {
                return Enumerable.Empty<T>();
            }

            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var output = ParseItems(doc);

                _logger.Info($"Parsed {output.Count} items");

                if (nextPage && Items != null)
                {
                    Items.AddRange(output);
                }
                else
                {
                    Items = output;
                }

                return output;
            }
            catch (Exception e)
            {
                _logger.Error("Parse error", e);
                return Enumerable.Empty<T>();
            }
        }
    }
}