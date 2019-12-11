using System.Net.Http;

namespace Api1.DataProvider
{
    public class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitilizeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
