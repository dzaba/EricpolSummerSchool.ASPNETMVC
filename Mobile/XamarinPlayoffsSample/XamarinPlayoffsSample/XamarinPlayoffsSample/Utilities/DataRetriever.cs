using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinPlayoffsSample.Utilities
{
    public static class DataRetriever
    {
        public static async Task<string> GetData(string url)
        {
            var client = new HttpClient();

            string data = await client.GetStringAsync(url);

            return data;
        }
    }
}
