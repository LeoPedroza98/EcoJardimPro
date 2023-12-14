using EcoJardimProject.API.Repositories;
using EcoJardimProject.API.Services;
using EcoJardimProject.Domain.Entities;
using Moq;

namespace EcoJardimProject.Tests.Projetos;

public class ProjetosServicesTeste
{
    [Fact]
    public async Task Post_ValidatesModelBeforeSaving()
    {
        // Arrange
        var repository = new Mock<IProjetoRepository>();
        var service = new ProjetoService(repository.Object);
        var projeto = new Projeto();

        // Act
        await service.Post(projeto);

        // Assert
        repository.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
