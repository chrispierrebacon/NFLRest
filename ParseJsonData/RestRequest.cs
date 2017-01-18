using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;

namespace ParseJsonData
{
    public class RestRequest<T> : IRestRequest<T>
    {
        public HttpResponseMessage MakeRequest(string endpoint, string path, T body, Method method, Dictionary<string, string> headers)
        {
            var client = new RestClient(endpoint);
            var request = new RestRequest(path, method);

            foreach(string key in headers.Keys)
            {
                request.AddHeader(key, headers[key]);
            }

            if (body != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(body);
            }

            IRestResponse response = client.Execute(request);

            return new HttpResponseMessage();
        }
    }
}
