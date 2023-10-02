using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarniceriaWebApi.Context;
using Sistema_Carnicería.Models;

namespace CarniceriaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobradoresController : ControllerBase
    {
        private readonly CarniceriaDbContext _context;

        public CobradoresController(CarniceriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Cobradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobrador>>> GetCobradores()
        {
          if (_context.Cobradores == null)
          {
              return NotFound();
          }
            return await _context.Cobradores.ToListAsync();
        }

        // GET: api/Cobradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cobrador>> GetCobrador(int id)
        {
          if (_context.Cobradores == null)
          {
              return NotFound();
          }
            var cobrador = await _context.Cobradores.FindAsync(id);

            if (cobrador == null)
            {
                return NotFound();
            }

            return cobrador;
        }

        // PUT: api/Cobradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobrador(int id, Cobrador cobrador)
        {
            if (id != cobrador.Id)
            {
                return BadRequest();
            }

            _context.Entry(cobrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobradorExists(id))
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

        // POST: api/Cobradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cobrador>> PostCobrador(Cobrador cobrador)
        {
          if (_context.Cobradores == null)
          {
              return Problem("Entity set 'CarniceriaDbContext.Cobradores'  is null.");
          }
            _context.Cobradores.Add(cobrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCobrador", new { id = cobrador.Id }, cobrador);
        }

        // DELETE: api/Cobradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobrador(int id)
        {
            if (_context.Cobradores == null)
            {
                return NotFound();
            }
            var cobrador = await _context.Cobradores.FindAsync(id);
            if (cobrador == null)
            {
                return NotFound();
            }

            _context.Cobradores.Remove(cobrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CobradorExists(int id)
        {
            return (_context.Cobradores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
