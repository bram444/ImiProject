using Imi.Project.Mobile.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

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

        public async Task<ApiResponse<TOut>> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }

        public async Task<ApiResponse<TOut>> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }

        public async Task<ApiResponse<TOut>> DeleteCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }

        private async Task<ApiResponse<TOut>> CallApi<TOut, TIn>(string uri, TIn entity, HttpMethod httpMethod)
        {
            try
            {
                HttpResponseMessage responseMessage = httpMethod == HttpMethod.Post
                    ? await this.PostAsync(uri, entity, GetJsonFormatter())
                    : httpMethod == HttpMethod.Put ? await this.PutAsync(uri, entity, GetJsonFormatter()) : await DeleteAsync(uri);

                ApiResponse<TOut> apiData = new ApiResponse<TOut>();
                if(responseMessage.IsSuccessStatusCode)
                {
                    return new ApiResponse<TOut>
                    {
                        IsSuccess = true,
                        ApiResponseData = await responseMessage.Content.ReadAsAsync<TOut>()
                    };
                }

                List<string> allErrors = new List<string>();
                string value = await responseMessage.Content.ReadAsStringAsync();
                if(value.Contains("errors"))
                {
                    var obj = new { errors = new Dictionary<string, string[]>() };
                    var validations = JsonConvert.DeserializeAnonymousType(value, obj);

                    List<string[]> allValidators = validations.errors.Values.ToList();

                    allValidators.ForEach(stringList => stringList.ForEach(singleError => allErrors.Add(singleError)));

                    return new ApiResponse<TOut>
                    {
                        IsSuccess = false,
                        Messages = allErrors
                    };
                }

                object[] allObjects = await responseMessage.Content.ReadAsAsync<object[]>();
                string[] stringArray = Array.ConvertAll(allObjects, o => o.ToString());
                allErrors.AddRange(stringArray);

                return new ApiResponse<TOut>
                {
                    IsSuccess = false,
                    Messages = allErrors
                };
            } catch(Exception ex)
            {
                return new ApiResponse<TOut>
                {
                    IsSuccess = false,
                    Messages = new List<string>() { ex.Message }
                };
            }
        }
    }
}
