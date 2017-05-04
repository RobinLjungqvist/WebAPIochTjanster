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
    public class AuthorsController : ApiController
    {
        private BooksDB db = new BooksDB();

        // GET: api/Authors
        public IHttpActionResult GetAuthors()
        {
            var authors = new List<Authors>();
            foreach (var a in db.Authors)
            {
                authors.Add(new Authors()
                {
                    AuthorID = a.AuthorID,
                    Age = a.Age,
                    CountryOfResidence = a.CountryOfResidence,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    HomeTel = a.HomeTel,
                    PaymetMethod = a.PaymetMethod,
                });
            }
            return Ok(authors);
        }

        // GET: api/Authors/5
        [ResponseType(typeof(Authors))]
        public IHttpActionResult GetAuthors(int id)
        {
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return NotFound();
            }

            return Json(authors);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthors(int id, Authors authors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authors.AuthorID)
            {
                return BadRequest();
            }

            db.Entry(authors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Authors))]
        public IHttpActionResult PostAuthors(Authors authors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(authors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = authors.AuthorID }, authors);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Authors))]
        public IHttpActionResult DeleteAuthors(int id)
        {
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return NotFound();
            }

            db.Authors.Remove(authors);
            db.SaveChanges();

            return Ok(authors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorsExists(int id)
        {
            return db.Authors.Count(e => e.AuthorID == id) > 0;
        }
    }
}