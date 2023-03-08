namespace ControlePonto.Entity.Entities
{
    public class RegistroPontoEntity : BaseEntity
    {
        public int IdColaborador { get; set; }
        public string Imagem { get; set; }
        public DateTime DtRegistroPonto { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ColaboradorEntity Colaborador { get; set; }
    }
}