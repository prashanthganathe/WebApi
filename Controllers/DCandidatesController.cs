using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidatesController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DCandidatesController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DCandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidates>>> GetDCandidates()
        {
            return await _context.DCandidates.ToListAsync();
        }

        // GET: api/DCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidates>> GetDCandidates(int id)
        {
            var dCandidates = await _context.DCandidates.FindAsync(id);

            if (dCandidates == null)
            {
                return NotFound();
            }

            return dCandidates;
        }

        // PUT: api/DCandidates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidates(int id, DCandidates dCandidates)
        {
            dCandidates.id = id;

            _context.Entry(dCandidates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidatesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DCandidates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DCandidates>> PostDCandidates(DCandidates dCandidates)
        {
            _context.DCandidates.Add(dCandidates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidates", new { id = dCandidates.id }, dCandidates);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DCandidates>> DeleteDCandidates(int id)
        {
            var dCandidates = await _context.DCandidates.FindAsync(id);
            if (dCandidates == null)
            {
                return NotFound();
            }

            _context.DCandidates.Remove(dCandidates);
            await _context.SaveChangesAsync();

            return dCandidates;
        }

        private bool DCandidatesExists(int id)
        {
            return _context.DCandidates.Any(e => e.id == id);
        }
    }
}
