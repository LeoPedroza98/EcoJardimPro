using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.Tests.Projetos;

public class ProjetosModelsTeste
{
    [Fact]
    public void NomeProjetoDeveSerObrigatorio()
    {
        // Arrange
        var projeto = new Projeto();

        // Act
        var result = projeto.ValidateProjeto();

        // Assert
        Assert.Contains("Nome do Projeto é obrigatório", result);
    }
    [Fact]
    public void DescricaoProjetoDeveSerObrigatorio()
    {
        // Arrange
        var projeto = new Projeto();

        // Act
        var result = projeto.ValidateProjeto();

        // Assert
        Assert.Contains("A Descrição do projeto é obrigatória", result);
    }
    [Fact]
    public void ValorProjetoDeveSerObrigatorio()
    {
        // Arrange
        var projeto = new Projeto();

        // Act
        var result = projeto.ValidateProjeto();

        // Assert
        Assert.Contains("O Valor do projeto é obrigatório", result);
    }
}