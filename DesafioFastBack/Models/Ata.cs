namespace DesafioFastBack.Models
{
    public class Ata
    {
        public int Id { get; set; }

        // Adicione esta linha: é o ID que liga ao Workshop
        public int WorkshopId { get; set; }
        
        // Mantenha a propriedade de navegação (opcionalmente como nula para o POST não exigir o objeto todo)
        public Workshop? workshop { get; set; }

        // Para os colaboradores, se for uma relação N para N, o ideal é manter a lista
        public List<Colaborador> Colaboradores { get; set; } = new List<Colaborador>(); 
    }
}
