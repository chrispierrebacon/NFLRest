using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFLBLL;
using Newtonsoft.Json;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Web.Http.Controllers;
using NFLCommon;


namespace NFLRESTAPI.Controllers
{
    public class PlayersController : ApiController
    {
        private SingleStatBL<Player> _playerBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _playerBL = (SingleStatBL<Player>)container.GetService(typeof(SingleStatBL<Player>));
            base.Initialize(controllerContext);
        }
        
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Player player)
        {
            Guid resp = _playerBL.Create(player);
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Add("Response", resp.ToString());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string filterJson)
        {
            string content = JsonConvert.SerializeObject(_playerBL.Get(filterJson));
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(content);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]string playerJson)
        {
            Player player = JsonConvert.DeserializeObject<Player>(playerJson);
            int resp = _playerBL.Update(player);
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.NoContent;
            response.Headers.Add("Response", resp.ToString());
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            int resp = _playerBL.Delete(id);
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Gone;
            response.Headers.Add("Response", resp.ToString());
            response.Headers.Add("Message", "Aaaaaaaaaand it's gone");
            return response;
        }
    }
}
