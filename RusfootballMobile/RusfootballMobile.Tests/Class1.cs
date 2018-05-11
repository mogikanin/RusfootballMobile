using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NUnit.Framework;
using RusfootballMobile.Services;

namespace RusfootballMobile.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public async Task Test()
        {
            var store = new LastNewsProvider();
            //var res = await store.GetItemsAsync(false);
        }
    }
}
