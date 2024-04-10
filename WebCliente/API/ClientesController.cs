using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCliente.Data;
using WebCliente.Models;
using System.Collections.Generic;
using System.Linq;


namespace WebCliente.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly WebClienteContext _context;

        public ClientesController(WebClienteContext context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return _context.Cliente.ToList();
        }

        // GET: 
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }


        // POST: 
        [HttpPost]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            if (_context.Cliente.Any(x => x.Email == cliente.Email))
            {
                return Conflict("E-mail já registrado.");
            }

            _context.Cliente.Add(cliente);
            _context.SaveChanges();
         
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteId }, cliente);
        }

        // PUT: 
        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
