using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using RestSharp;

namespace NFLMVC.Helpers
{
    public class RestHelper<T>
    {
        public static IRestResponse MakeRequest(string endpoint, string path, T body, Method method, Dictionary<string, string> headers)
        {
            var client = new RestClient(endpoint);
            var request = new RestRequest(path, method);

            foreach (string key in headers.Keys)
            {
                request.AddHeader(key, headers[key]);
            }

            if (body != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(body);
            }

            return client.Execute(request);
            
        }
    }
}