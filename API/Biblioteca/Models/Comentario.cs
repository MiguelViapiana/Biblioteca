public class Comentario
{
    public int ComentarioId { get; set; } // Adiciona uma propriedade para a chave primária
    public string Texto { get; set; }
    public string Usuario { get; set; }
    public string LivroId { get; set; }
}
