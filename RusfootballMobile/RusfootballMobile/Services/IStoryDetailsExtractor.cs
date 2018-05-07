using System.Threading.Tasks;
using RusfootballMobile.Models;

namespace RusfootballMobile.Services
{
    public interface IStoryDetailsExtractor
    {
        Task<string> GetDetails(IStory story);
    }
}