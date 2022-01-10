using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Models
{
    public class BancoDeDados : DbContext
    {
        public DbSet<ProdutosDaMandiocultura> ProdutosDaMandiocultura { get; set; }

        public DbSet<VendaDeArtesanatos> VendaDeArtesanatos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=meuservidorb.database.windows.net;database=MeuBancoTesteTres;User ID=adminserver;Password=YsRt$sql");
        }
    }
}
