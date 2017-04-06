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
using NFLCommon.BLLInterfaces;

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

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public HttpResponseMessage Post([FromBody]GameStats value)
        {
            int resp = _statsBL.Create(value);
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Add("Response", resp.ToString());
            return response;
        }

        public void Put(int id, [FromBody]GameStats value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
