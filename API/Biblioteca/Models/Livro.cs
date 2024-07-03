namespace API.Biblioteca.Models;

public class Livro{

    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public string Categoria { get; set; }
    public string LivroId { get; set; }
    public bool Emprestado { get; set; }

    public  ICollection<Avaliacao> Avaliacoes { get; } = new List<Avaliacao>();
    public List<Comentario> Comentarios { get; set; }

    public Livro(string titulo, string autor, string editora, string categoria){
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        Categoria = categoria;
        LivroId = Guid.NewGuid().ToString();
    }

}
