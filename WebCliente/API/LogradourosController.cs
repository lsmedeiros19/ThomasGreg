using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCliente.Data;
using WebCliente.Models;

namespace WebCliente.API
{
    public class LogradourosController : ControllerBase
    {
        private readonly WebClienteContext _context;

        public LogradourosController(WebClienteContext context)
        {
            _context = context;
        }

        // GET: api/Logradouros
        [HttpGet]
        public ActionResult<IEnumerable<Logradouro>> GetLogradouros()
        {
            return _context.Logradouro.ToList();
        }

        // GET: api/Logradouros/5
        [HttpGet("{id}")]
        public ActionResult<Logradouro> GetLogradouro(int id)
        {
            var logradouro = _context.Logradouro.Find(id);

            if (logradouro == null)
            {
                return NotFound();
            }

            return logradouro;
        }

        // POST: api/Logradouros
        [HttpPost]
        public ActionResult<Logradouro> PostLogradouro(Logradouro logradouro)
        {
            _context.Logradouro.Add(logradouro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLogradouro), new { id = logradouro.LogradouroId }, logradouro);
        }

        // PUT: api/Logradouros/5
        [HttpPut("{id}")]
        public IActionResult PutLogradouro(int id, Logradouro logradouro)
        {
            if (id != logradouro.LogradouroId)
            {
                return BadRequest();
            }

            _context.Entry(logradouro).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Logradouros/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLogradouro(int id)
        {
            var logradouro = _context.Logradouro.Find(id);
            if (logradouro == null)
            {
                return NotFound();
            }

            _context.Logradouro.Remove(logradouro);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
