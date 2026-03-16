namespace DesafioFastBack.Models
{
    public class Ata
    {
        public int Id { get; set; }
        
        // Use o nome da propriedade exatamente como está na sua Controller (singular)
        public Workshop workshop { get; set; } = new Workshop();
        
        // Use o nome da propriedade exatamente como está na sua Controller (singular)
        public List<Colaborador> Colaborador { get; set; } = new List<Colaborador>(); 
    }
}
