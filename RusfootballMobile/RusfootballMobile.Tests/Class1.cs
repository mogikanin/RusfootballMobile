using System.Threading.Tasks;
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
            await store.GetItemsAsync(true, delegate {  });
        }
    }
}
