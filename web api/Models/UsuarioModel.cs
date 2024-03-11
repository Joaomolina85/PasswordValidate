namespace web_api.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string senha { get; set; }
        public string? email { get; set; }
    }
}
