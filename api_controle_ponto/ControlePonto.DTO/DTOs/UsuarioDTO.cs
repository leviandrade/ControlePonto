namespace ControlePonto.DTO.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NmUsuario { get; set; }
        public string NrCpf { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
