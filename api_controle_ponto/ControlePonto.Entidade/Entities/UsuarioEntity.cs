using ControlePonto.Helpers;

namespace ControlePonto.Entity.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string NmUsuario { get; set; }
        public string NrCpf { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }

        public void CriptografarSenha()
        {
            Senha = CriptografiaHelper.Criptografar(Senha);
        }
    }
}
