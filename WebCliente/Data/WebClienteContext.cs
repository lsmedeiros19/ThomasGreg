using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCliente.Models;

namespace WebCliente.Data
{
    public class WebClienteContext : DbContext
    {
        public WebClienteContext (DbContextOptions<WebClienteContext> options)
            : base(options)
        {
        }

        public DbSet<WebCliente.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<WebCliente.Models.Logradouro> Logradouro { get; set; } = default!;
    }
}
