using EcoJardimProject.API.Controllers;
using EcoJardimProject.API.Services;
using EcoJardimProject.Domain.Entities;
using EcoJardimProject.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EcoJardimProject.Tests.Projetos;

public class ProjetoControllerTeste
{
    [Fact]
    public async Task Post_ReturnsBadRequestOnError()
    {
        // Arrange
        var logger = new Mock<ILogger<ProjetoController>>();
        var service = new Mock<IProjetoService>();
        service.Setup(s => s.Post(It.IsAny<Projeto>())).Throws(new BadRequestException("Mensagem de erro"));
        var controller = new ProjetoController(logger.Object, service.Object);

        var projeto = new Projeto();

        // Act
        var result = await controller.Post(projeto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Mensagem de erro", badRequestResult.Value);
    }
}