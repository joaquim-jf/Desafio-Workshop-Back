namespace DesafioFastBack.Models
{
   {
    public class Ata
    {
        public int Id { get; set; }
        public Workshop? workshop { get; set; } 
        public List<Colaborador> Colaborador { get; set; } = new List<Colaborador>(); 
        }
}
}
