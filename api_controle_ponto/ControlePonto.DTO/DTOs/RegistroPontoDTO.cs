namespace ControlePonto.DTO.DTOs
{
    public class RegistroPontoDTO
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public string CPF { get; set; }
        public string Imagem { get; set; }
        public DateTime DtRegistroPonto { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
