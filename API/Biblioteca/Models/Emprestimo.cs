namespace API.Biblioteca.Models;
public class Emprestimo{

    public string EmprestimoId { get; set; }
    public string UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public string LivroId { get; set; }
    public Livro Livro { get; set; }
    public DateTime? DataEmprestimo { get; set; }
    public Emprestimo()
    {
    }

    public Emprestimo(string usuarioId, string livroId)
    {
        EmprestimoId = Guid.NewGuid().ToString();
        UsuarioId = usuarioId;
        LivroId = livroId;
    }
}