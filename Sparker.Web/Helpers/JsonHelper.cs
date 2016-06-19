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
    }
}