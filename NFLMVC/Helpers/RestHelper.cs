using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace NFLMVC.Helpers
{
    public class RestHelper<T>
    {
        public static IRestResponse MakeRequest(string endpoint, string path, T body, Method method, Dictionary<string, string> headers, NFLFilter filterParams)
        {
            var client = new RestClient(endpoint);
            var request = new RestRequest(path, method);

            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    request.AddHeader(key, headers[key]);
                } 
            }

            request.AddQueryParameter("filterJson", JsonConvert.SerializeObject(filterParams));

            if (body != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(body);
            }

            return client.Execute(request);
        }
    }

    public class NFLFilter
    {
        public Guid Id { get; set; }
    }
}