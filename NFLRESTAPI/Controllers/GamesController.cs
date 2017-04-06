using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using NFLBLL;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http.Controllers;
using Autofac;
using System;
using NFLCommon;
using NFLCommon.BLLInterfaces;
using System.Linq;

namespace NFLRESTAPI.Controllers
{
    public class GamesController : ApiController
    {
        private IBLCrud<Game> _gameBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _gameBL = (IBLCrud<Game>)container.GetService(typeof(IBLCrud<Game>));
            base.Initialize(controllerContext);
        }

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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
        public HttpResponseMessage Get(string id = "")
        {
            string content = (string.IsNullOrEmpty(id))
                ? JsonConvert.SerializeObject(_gameBL.GetAll().ToList()) 
                : JsonConvert.SerializeObject(_gameBL.Get(Guid.Parse(id)));
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Id", id.ToString());
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
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            int resp = _gameBL.Delete(id);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.Gone;
            return response;
        }
    }
}
