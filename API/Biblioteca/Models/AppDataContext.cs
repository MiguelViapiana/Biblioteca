using API.Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> TabelaUsuarios { get; set; }
    public DbSet<Livro> TabelaLivros { get; set; }
    public DbSet<Emprestimo> TabelaEmprestimos { get; set; }
    public DbSet<Devolucao> TabelaDevolucao { get; set; }
    public DbSet<Comentario> TabelaComentario { get; set; }
    public DbSet<Avaliacao> TabelaAvalicao { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=biblioteca.db");
    }
}