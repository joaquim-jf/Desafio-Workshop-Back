using System.Data;

namespace DesafioFastBack.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public DateTime DataRealizacao { get; set; }
    }
}
