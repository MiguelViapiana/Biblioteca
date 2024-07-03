namespace API.Biblioteca.Models;

public class Avaliacao

{
   
    public int AvaliacaoId { get; set; } // Adiciona uma propriedade para a chave primária
    public int Estrelas { get; set; }
    public string Usuario { get; set; }

    public string LivroId { get; set; }
}
