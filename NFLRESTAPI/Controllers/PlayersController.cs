﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFLObjects;
using NFLBLL;
using Newtonsoft.Json;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using NFLObjects.Objects;
using System.Web.Http.Controllers;

namespace NFLRESTAPI.Controllers
{
    public class PlayersController : ApiController
    {
        private IBLCrud<Player> _playerBL;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            var container = controllerContext.Configuration.DependencyResolver.BeginScope();
            _playerBL = (IBLCrud<Player>)container.GetService(typeof(IBLCrud<Player>));
            base.Initialize(controllerContext);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public HttpResponseMessage Get(Guid id)
        {
            Player player = _playerBL.Get(id);
            string content = JsonConvert.SerializeObject(player);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Id", id.ToString());
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
