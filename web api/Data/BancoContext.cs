using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using web_api.Models;

namespace web_api.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> usuario { get; set; }
        public DbSet<UsuarioObs>obs_usuario { get; set; }
    }
}
