using Blazorapp5.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorapp5.BD.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Rol> Roles => Set<Rol>();

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        public DbSet<Carrito> Carritos => Set<Carrito>();

        public DbSet<Producto> Productos => Set<Producto>();


    }
}
