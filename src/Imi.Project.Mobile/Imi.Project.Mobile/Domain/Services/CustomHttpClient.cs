using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class CustomHttpClient: HttpClient
    {
        public CustomHttpClient() : base(CreateClientHandler())
        {
        }

        private JsonMediaTypeFormatter GetJsonFormatter()
        {
            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return formatter;
        }

        private static HttpClientHandler CreateClientHandler()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
#if DEBUG
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
#endif
            return httpClientHandler;
        }

        public async Task<T> GetApiResult<T>(string uri)
        {
            string response = await GetStringAsync(uri);
            return JsonConvert.DeserializeObject<T>(response, GetJsonFormatter().SerializerSettings);
        }

        public async Task<TOut> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }

        public async Task<TOut> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }

        public async Task<TOut> DeleteCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }

        private async Task<TOut> CallApi<TOut, TIn>(string uri, TIn entity, HttpMethod httpMethod)
        {
            HttpResponseMessage response = httpMethod == HttpMethod.Post
                ? await this.PostAsync(uri, entity, GetJsonFormatter())
                : httpMethod == HttpMethod.Put ? await this.PutAsync(uri, entity, GetJsonFormatter()) : await DeleteAsync(uri);

            //if(!response.IsSuccessStatusCode)
            //{
            //    TOut result = await response.;

            //    return result;
            //}
            TOut result = await response.Content.ReadAsAsync<TOut>();

            return result;
        }
    }
}
