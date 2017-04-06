using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFLBLL;
using Newtonsoft.Json;
using System.Web.Http.Controllers;
using NFLCommon;


namespace NFLRESTAPI.Controllers
{
    public class TeamsController : ApiController
    {
        private SingleStatBL<Team> _teamBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _teamBL = (SingleStatBL<Team>)container.GetService(typeof(SingleStatBL<Team>));
            base.Initialize(controllerContext);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Team team)
        {
            Guid resp = _teamBL.Create(team);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string filterJson)
        {
            string content = JsonConvert.SerializeObject(_teamBL.Get(filterJson));
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(content);
            return response;
        }        

        [HttpPut]
        public HttpResponseMessage Put([FromBody]Team team)
        {
            int resp = _teamBL.Update(team);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            int resp = _teamBL.Delete(id);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Response", resp.ToString());
            response.StatusCode = HttpStatusCode.Gone;
            return response;
        }
    }
}
