using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.Controllers
{
    public class PlayerAPIController : ApiController
    {
        private Contexts db = new Contexts();

        // GET api/PlayerAPI
        public IEnumerable<PlayerModel> GetPlayerModels()
        {
            return db.PlayerModels.AsEnumerable();
        }

        // GET api/PlayerAPI/?name=albert
        public PlayerModel GetPlayerModel(string name)
        {
            PlayerModel playermodel = db.PlayerModels.FirstOrDefault(x => x.Name == name);
            if (playermodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return playermodel;
        }

        // GET api/PlayerAPI/5
        public PlayerModel GetPlayerModel(int id)
        {
            PlayerModel playermodel = db.PlayerModels.FirstOrDefault(x => x.ID == id);
            if (playermodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return playermodel;
        }

        // PUT api/PlayerAPI/5
        public HttpResponseMessage PutPlayerModel(int id, PlayerModel playermodel)
        {
            if (ModelState.IsValid && id == playermodel.ID)
            {
                db.Entry(playermodel).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/PlayerAPI
        public HttpResponseMessage PostPlayerModel(PlayerModel playermodel)
        {
            if (ModelState.IsValid)
            {
                db.PlayerModels.Add(playermodel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, playermodel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = playermodel.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/PlayerAPI/5
        public HttpResponseMessage DeletePlayerModel(int id)
        {
            PlayerModel playermodel = db.PlayerModels.Find(id);
            if (playermodel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PlayerModels.Remove(playermodel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, playermodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}