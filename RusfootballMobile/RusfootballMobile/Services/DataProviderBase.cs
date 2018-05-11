using System;
using System.Collections.Generic;
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
        private readonly Encoding _enc1251 = Encoding.GetEncoding(1251);

        protected DataProviderBase(string host)
        {
            Host = host;
            _logger = LoggerFactory.GetLogger(GetType());
        }

        protected string Host { get; }
        protected abstract IEnumerable<T> ParseItems(HtmlDocument document);

        public async Task GetItemsAsync(bool nextPage, Action<T> onNewItem)
        {
            string html = null;
            try
            {
                var host = Host;
                if (nextPage)
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

                html = _enc1251.GetString(bytes);
            }
            catch (Exception e)
            {
                _logger.Error("Load error", e);
            }

            if (string.IsNullOrEmpty(html))
            {
                return;
            }

            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                _logger.Info("Html loaded");

                var counter = 0;
                foreach (var item in ParseItems(doc))
                {
                    onNewItem(item);
                    counter++;
                }

                _logger.Info($"Parsed {counter} items");
            }
            catch (Exception e)
            {
                _logger.Error("Parse error", e);
            }
        }
    }
}