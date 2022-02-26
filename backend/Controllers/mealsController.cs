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
using backend.Models;

namespace backend.Controllers
{
    public class mealsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/meals
        public IQueryable<meals> Getmeals()
        {
            return db.meals;
        }

        // GET: api/meals/5
        [ResponseType(typeof(meals))]
        public IHttpActionResult Getmeals(int id)
        {
            meals meals = db.meals.Find(id);
            if (meals == null)
            {
                return NotFound();
            }

            return Ok(meals);
        }

        // PUT: api/meals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmeals(int id, meals meals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meals.id)
            {
                return BadRequest();
            }

            db.Entry(meals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mealsExists(id))
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

        // POST: api/meals
        [ResponseType(typeof(meals))]
        public IHttpActionResult Postmeals(meals meals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.meals.Add(meals);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meals.id }, meals);
        }

        // DELETE: api/meals/5
        [ResponseType(typeof(meals))]
        public IHttpActionResult Deletemeals(int id)
        {
            meals meals = db.meals.Find(id);
            if (meals == null)
            {
                return NotFound();
            }

            db.meals.Remove(meals);
            db.SaveChanges();

            return Ok(meals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mealsExists(int id)
        {
            return db.meals.Count(e => e.id == id) > 0;
        }
    }
}