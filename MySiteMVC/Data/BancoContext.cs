using Microsoft.EntityFrameworkCore;
using MySiteMVC.Models;

namespace MySiteMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> op) : base(op)
        {

        }

        public BancoContext() { }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
