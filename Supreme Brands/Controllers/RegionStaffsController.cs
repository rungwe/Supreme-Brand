using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Supreme_Brands.Models;

namespace Supreme_Brands.Controllers
{
    public class RegionStaffsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RegionStaffs
        public IQueryable<RegionStaff> GetRegionStaffs()
        {
            return db.RegionStaffs;
        }

        // GET: api/RegionStaffs/5
        [ResponseType(typeof(RegionStaff))]
        public async Task<IHttpActionResult> GetRegionStaff(int id)
        {
            RegionStaff regionStaff = await db.RegionStaffs.FindAsync(id);
            if (regionStaff == null)
            {
                return NotFound();
            }

            return Ok(regionStaff);
        }

        // PUT: api/RegionStaffs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegionStaff(int id, RegionStaff regionStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != regionStaff.id)
            {
                return BadRequest();
            }

            db.Entry(regionStaff).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionStaffExists(id))
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

        // POST: api/RegionStaffs
        [ResponseType(typeof(RegionStaff))]
        public async Task<IHttpActionResult> PostRegionStaff(RegionStaff regionStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegionStaffs.Add(regionStaff);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = regionStaff.id }, regionStaff);
        }

        // DELETE: api/RegionStaffs/5
        [ResponseType(typeof(RegionStaff))]
        public async Task<IHttpActionResult> DeleteRegionStaff(int id)
        {
            RegionStaff regionStaff = await db.RegionStaffs.FindAsync(id);
            if (regionStaff == null)
            {
                return NotFound();
            }

            db.RegionStaffs.Remove(regionStaff);
            await db.SaveChangesAsync();

            return Ok(regionStaff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegionStaffExists(int id)
        {
            return db.RegionStaffs.Count(e => e.id == id) > 0;
        }
    }
}