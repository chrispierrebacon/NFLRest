using System.Web.Http;
using System.Net.Http;
using NFLBLL;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http.Controllers;
using System;
using NFLCommon;

namespace NFLRESTAPI.Controllers
{
    public class GamesController : ApiController
    {
        private SingleStatBL<Game> _gameBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _gameBL = (SingleStatBL<Game>)container.GetService(typeof(SingleStatBL<Game>));
            base.Initialize(controllerContext);
        }
        
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Game game)
        {
            Guid resp = _gameBL.Create(game);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] string filterJson = "")
        {
            string content = JsonConvert.SerializeObject(_gameBL.Get(filterJson));
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(content);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]Game game)
        {
            int resp = _gameBL.Update(game);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            int resp = _gameBL.Delete(id);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
    }
}
