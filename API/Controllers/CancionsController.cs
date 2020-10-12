using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionsController : ControllerBase
    {
        private readonly APIContext _context;

        public CancionsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cancions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCancion()
        {
            return await _context.Cancion.ToListAsync();
        }

        // GET: api/Cancions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
            var cancion = await _context.Cancion.FindAsync(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return cancion;
        }

        // PUT: api/Cancions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancion(int id, Cancion cancion)
        {
            if (id != cancion.CancionId)
            {
                return BadRequest();
            }

            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(id))
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

        // POST: api/Cancions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion(Cancion cancion)
        {
            _context.Cancion.Add(cancion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancion", new { id = cancion.CancionId }, cancion);
        }

        // DELETE: api/Cancions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cancion>> DeleteCancion(int id)
        {
            var cancion = await _context.Cancion.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Cancion.Remove(cancion);
            await _context.SaveChangesAsync();

            return cancion;
        }

        private bool CancionExists(int id)
        {
            return _context.Cancion.Any(e => e.CancionId == id);
        }
    }
}
