using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.Tests.Clientes
{
    public class ClientesModelsTeste
    {
        [Fact]
        public void NomeDeveSerObrigatorio()
        {
            // Arrange
            var cliente = new Cliente();

            // Act
            var result = cliente.Validate();

            // Assert
            Assert.Contains("Nome é obrigatório", result);
        }
        
        [Fact]
        public void SobrenomeDeveSerObrigatorio()
        {
            // Arrange
            var cliente = new Cliente();

            // Act
            var result = cliente.Validate();

            // Assert
            Assert.Contains("Sobrenome é obrigatório", result);
        }
    }
}
