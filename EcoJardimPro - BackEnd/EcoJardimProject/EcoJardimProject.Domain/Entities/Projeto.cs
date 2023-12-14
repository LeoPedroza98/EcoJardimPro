using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Projeto : IEntity
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public long StatusId { get; set; }
    public Status? Status { get; private set; }
    public DateTime PrazoInicial { get; set; }
    public DateTime PrazoFinal { get; set; }
    public decimal Valor { get; set; }
    public long ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    
    
    public List<string> ValidateProjeto()
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(Nome))
        {
            errors.Add("Nome do Projeto é obrigatório");
        }

        if (string.IsNullOrEmpty(Descricao))
        {
            errors.Add("A Descrição do projeto é obrigatória");
        }
        
        if (Valor <= 0)
        {
            errors.Add("O Valor do projeto é obrigatório");
        }
        return errors;
    }
}