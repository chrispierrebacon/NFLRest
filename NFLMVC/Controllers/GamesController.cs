using NFLMVC.Helpers;
using NFLMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace NFLMVC.Controllers
{
    public class GamesController : Controller
    {

        // GET: Games
        public ActionResult Index()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };

            GamesFilter filter = new GamesFilter
            {
                Season = 2016
            };

            var response = RestHelper<Game>.MakeRequest("http://localhost:49786", "api/games", null, Method.GET, headers, filter);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseJson = response.Content;
                IEnumerable<Game> games = JsonConvert.DeserializeObject<IEnumerable<Game>>(responseJson);
                return View(games);
            }
            else
            {
                // TODO: Make an error page or try again?
                return View();
            }
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Figure out how to populate this object
                Game game = null;

                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };

                var response = RestHelper<Game>.MakeRequest("http://localhost:49786", "api/games", game, Method.POST, headers, null);

                if(response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // TODO: Some error page
                    throw new NotImplementedException();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Games/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Figure out how to get this object from the form
                Game game = null;

                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                };

                var response = RestHelper<Game>.MakeRequest("http://localhost:49786", "api/games", game, Method.PUT, headers, null);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // TODO: Go back go the details page???
                    return RedirectToAction("Index");                    
                }
                else
                {
                    // TODO: Error page bra
                    throw new NotImplementedException();
                }

            }
            catch
            {
                return View();
            }
        }

        // TODO: Figure out a good way of doing deletion
        // This clearly doesn't need more than an Id for deletion
        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Games/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    public class GamesFilter : NFLFilter
    {
        public bool PreSeasonOn { get; set; } = false;
        public bool PostSeasonOn { get; set; } = true;
        public bool RegSeasonOn { get; set; } = true;
        public int Season { get; set; }
        // When the nfl was founded. It would be cool to have all this data
        public DateTime StartDate { get; set; } = new DateTime(1920, 8, 20);
        // Some time far in the future
        public DateTime EndDate { get; set; } = new DateTime(2100, 1, 1);
    }
}
