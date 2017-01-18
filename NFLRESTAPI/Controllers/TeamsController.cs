using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NFLObjects.Objects;
using NFLBLL;
using Newtonsoft.Json;
using System.Web.Http.Controllers;

namespace NFLRESTAPI.Controllers
{
    public class TeamsController : ApiController
    {
        private IBLCrud<Team> _teamBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _teamBL = (IBLCrud<Team>)container.GetService(typeof(IBLCrud<Team>));
            base.Initialize(controllerContext);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Get a list of teams
            return new string[] { "value1", "value2" };
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
        public HttpResponseMessage Get(Guid id)
        {
            Team team = _teamBL.Get(id);
            string content = JsonConvert.SerializeObject(team);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Id", id.ToString());
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
