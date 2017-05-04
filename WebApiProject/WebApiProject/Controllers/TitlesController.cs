using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiProject;

namespace WebApiProject.Controllers
{
    public class TitlesController : ApiController
    {
        private BooksDB db = new BooksDB();

        // GET: api/Titles
        public IHttpActionResult GetTitles()
        {
            var titles = new List<Titles>();
            foreach (var title in db.Titles)
            {
                titles.Add(new Titles()
                {
                    Title = title.Title,
                    Copyright = title.Copyright,
                    EditionNumber = title.EditionNumber,
                    ISBN = title.ISBN,
                });
            }
            return Json(titles);
        }

        // GET: api/Titles/5
        [ResponseType(typeof(Titles))]
        public IHttpActionResult GetTitles(string isbn)
        {
            Titles titles = db.Titles.FirstOrDefault(t => t.ISBN == isbn);
            if (titles == null)
            {
                return NotFound();
            }
            var title = new Titles()
            {
                Copyright = titles.Copyright,
                ISBN = titles.ISBN,
                Title = titles.Title,
                EditionNumber = titles.EditionNumber

            };
            return Ok(title);
        }

        // PUT: api/Titles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTitles(string id, Titles titles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != titles.ISBN)
            {
                return BadRequest();
            }

            db.Entry(titles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitlesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Titles
        [ResponseType(typeof(Titles))]
        public IHttpActionResult PostTitles(Titles titles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Titles.Add(titles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TitlesExists(titles.ISBN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = titles.ISBN }, titles);
        }

        // DELETE: api/Titles/5
        [ResponseType(typeof(Titles))]
        public IHttpActionResult DeleteTitles(string id)
        {
            Titles titles = db.Titles.Find(id);
            if (titles == null)
            {
                return NotFound();
            }

            db.Titles.Remove(titles);
            db.SaveChanges();

            return Ok(titles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TitlesExists(string id)
        {
            return db.Titles.Count(e => e.ISBN == id) > 0;
        }
    }
}