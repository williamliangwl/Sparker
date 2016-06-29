using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Sparker.Web.Helpers
{
    public class JsonHelper
    {
        private Uri BaseAddress = null;

        private JsonHelper() { }

        public JsonHelper(string BaseAddressLink)
        {
            this.BaseAddress = new Uri(BaseAddressLink);
        }

        public async Task<T> Get<T>(string apiLink)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                apiLink = client.BaseAddress + apiLink;
                HttpResponseMessage response = await client.GetAsync(apiLink);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonResult);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return default(T);
            }
        }

        public async Task<T> Post<T>(string apiLink, T data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiLink, data);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonResult);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return default(T);
            }
        }

        public async Task<T> Post<T>(string apiLink, params KeyValuePair<string, object>[] content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                apiLink = client.BaseAddress + apiLink;

                List<KeyValuePair<string, string>> formContent = new List<KeyValuePair<string, string>>();
                foreach (KeyValuePair<string, object> item in content)
                {
                    string serializeResult = JsonConvert.SerializeObject(item.Value);
                    formContent.Add(new KeyValuePair<string, string>(item.Key, serializeResult));
                }

                HttpResponseMessage response = await client.PostAsync(apiLink, new FormUrlEncodedContent(formContent));
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonResult);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return default(T);
            }
        }

        public async Task<T> Put<T>(string apiLink, T data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(apiLink, data);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonResult);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return default(T);
            }
        }

        //public async Task<T> Delete<T>(string apiLink, T data)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = BaseAddress;
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
        //    }
        //}
    }
}