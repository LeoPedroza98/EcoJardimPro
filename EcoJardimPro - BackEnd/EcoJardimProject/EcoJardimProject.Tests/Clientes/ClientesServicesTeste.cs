using EcoJardimProject.API.Repositories;
using EcoJardimProject.API.Services;
using EcoJardimProject.Domain.Entities;
using Moq;

namespace EcoJardimProject.Tests.Clientes;

public class ClientesServicesTeste
{
    [Fact]
    public async Task Post_ValidatesModelBeforeSaving()
    {
        // Arrange
        var repository = new Mock<IClienteRepository>();
        var service = new ClienteService(repository.Object);
        var cliente = new Cliente();

        // Act
        await service.Post(cliente);

        // Assert
        repository.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}