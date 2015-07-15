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
    public class TeamAPIController : ApiController
    {
        private Contexts db = new Contexts();

        // GET api/TeamAPI
        public IEnumerable<TeamModel> GetTeamModels()
        {
            return db.Teams.AsEnumerable();
        }

        // GET api/TeamAPI/5
        public TeamModel GetTeamModel(int id)
        {
            TeamModel teammodel = db.Teams.Find(id);
            if (teammodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return teammodel;
        } 
        
        // GET api/TeamAPI/5
        public TeamModel GetTeamModel(string name)
        {
            TeamModel teammodel = db.Teams.Find(name);
            if (teammodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return teammodel;
        }

        // PUT api/TeamAPI/5
        public HttpResponseMessage PutTeamModel(int id, TeamModel teammodel)
        {
            if (ModelState.IsValid && id == teammodel.ID)
            {
                db.Entry(teammodel).State = EntityState.Modified;

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

        // POST api/TeamAPI
        public HttpResponseMessage PostTeamModel(TeamModel teammodel)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teammodel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, teammodel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = teammodel.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/TeamAPI/5
        public HttpResponseMessage DeleteTeamModel(int id)
        {
            TeamModel teammodel = db.Teams.Find(id);
            if (teammodel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Teams.Remove(teammodel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, teammodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}