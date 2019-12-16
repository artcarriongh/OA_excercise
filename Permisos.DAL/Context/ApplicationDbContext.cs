using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Permisos.Domain;

namespace Permisos.DAL
{
    public  class ApplicationDbContext : DbContext
    {
        private readonly IOptions<ConnectionStringOption> _connStrOptions;
        public ApplicationDbContext(IOptions<ConnectionStringOption> conStrOptions, DbContextOptions options) : base(options)
        {
            _connStrOptions = conStrOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStrOptions.Value.ConStr);
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Permiso> Permiso { get; set; }

        public virtual DbSet<TipoPermiso> TipoPermiso { get; set; }
    }
}
