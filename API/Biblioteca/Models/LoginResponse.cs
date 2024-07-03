namespace API.Biblioteca.Models;
public class LoginResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public Permissao Permissao { get; set; }

    public string Usuario {get; set; }
    public string UsuarioId {get; set;}
}
