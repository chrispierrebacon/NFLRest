using NFLBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using NFLCommon;
using Newtonsoft.Json;
using System.Text;

namespace NFLRESTAPI.Controllers
{
    public class StatsController : ApiController
    {
        private StatsBL _statsBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _statsBL = (StatsBL)container.GetService(typeof(StatsBL));
            base.Initialize(controllerContext);
        }

        public string[] Get()
        {
            return new string[] { "TeamName", "GameId" };
        }

        public HttpResponseMessage Get([FromUri]string GameId)
        {
            string content = JsonConvert.SerializeObject(_statsBL.GetCondensedGameStats(Guid.Parse(GameId)));
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(content);
            return response;
        }

        public HttpResponseMessage Post([FromBody]GameStats value)
        {
            int resp = _statsBL.Create(value);
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Add("Response", resp.ToString());
            return response;
        }

        public HttpResponseMessage Put(int id, [FromBody]GameStats value)
        {
            return null;
        }

        public HttpResponseMessage Delete(int id)
        {
            return null;
        }
    }
}
