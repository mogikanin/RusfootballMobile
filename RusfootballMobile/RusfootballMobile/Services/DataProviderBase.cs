using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RusfootballMobile.Services
{
    public abstract class DataProviderBase<T> : IDataProvider<T>
    {
        private int _page = 1;

        protected DataProviderBase(string host)
        {
            Host = host;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
                return Enumerable.Empty<T>();
            }

            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var output = ParseItems(doc);

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
                Console.WriteLine(e);
                return Enumerable.Empty<T>();
            }
        }
    }
}