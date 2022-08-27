namespace BlogSemEntity.Models
{
    public class Usuario : BaseModel
    {
        public Usuario(string? nome, string? email)
        {
            Nome = nome;
            Email = email;
        }
        
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}