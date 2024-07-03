namespace API.Biblioteca.Models;

public class Usuario{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string UsuarioId { get; set; }

    public Permissao Permissao {get; set;}

    public Usuario(string nome, string email, string senha){
        UsuarioId = Guid.NewGuid().ToString();
        Nome = nome;
        Email = email;
        Senha = senha;
        Permissao = Permissao.COMUM;
    }


}