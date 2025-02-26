namespace API.External.MKT.Database.Model;

public class Message
{
    public int Id { get; set; }
    public string Title { get; set; } // Título da mensagem
    public string Content { get; set; } // Conteúdo da mensagem
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação
}
