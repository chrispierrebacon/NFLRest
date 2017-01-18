using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ParseJsonData
{
    public interface IRestRequest<T>
    {
        HttpResponseMessage MakeRequest(string client, string path, T body, Method method, Dictionary<string, string> headers);
    }
}
