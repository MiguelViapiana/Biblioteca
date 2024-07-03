namespace API.Biblioteca.Models;
public class Devolucao
{

public string DevolucaoId { get; set; }
public string? EmprestimoId { get; set; }

public string LivroId { get; set; }

public string UsuarioId { get; set; }
//public Emprestimo? Emprestimo { get; set; }
public DateTime? DataDevolucao { get; set; }

public Devolucao( string livroId, string usuarioId){
        DevolucaoId = Guid.NewGuid().ToString();
        LivroId = livroId;
        UsuarioId = usuarioId;
}

}