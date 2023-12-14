using EcoJardimProject.API.Controllers;
using EcoJardimProject.API.Services;
using EcoJardimProject.Domain.Entities;
using EcoJardimProject.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EcoJardimProject.Tests.Clientes;

public class ClientesControllerTeste
{
    [Fact]
    public async Task Post_ReturnsBadRequestOnError()
    {
        // Arrange
        var logger = new Mock<ILogger<ClienteController>>();
        var service = new Mock<IClienteService>();
        service.Setup(s => s.Post(It.IsAny<Cliente>())).Throws(new BadRequestException("Mensagem de erro"));
        var controller = new ClienteController(logger.Object, service.Object);

        var cliente = new Cliente();

        // Act
        var result = await controller.Post(cliente);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Mensagem de erro", badRequestResult.Value);
    }
}