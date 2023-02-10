using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Usuario.Convertidores;
using Usuario.Dtos;
using Usuario.Models;
using Usuario.Controllers;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Usuario.Tests
{
    public class ClienteControllerTest
    {
        [Fact]
        public async Task GetAllAsync_ReturnsOkObjectResult_WithClienteDtos()
        {
            // Arrange
            var mockRepository = new Mock<IRepositorio<Cliente>>();
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "John Doe",
                Direccion = "123 Main St",
                Edad = 30,
                Identificacion = "123456789",
                Password = "password",
                Telefono = "555-555-5555",
                Genero = "Male"
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new[] { cliente });
            var controller = new ClienteController(mockRepository.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var clientes = Assert.IsAssignableFrom<IEnumerable<ClienteDto>>(okResult.Value);
            Assert.Equal(1, clientes.Count());
            Assert.Equal(cliente.ToDto(), clientes.First());
        }

        [Fact]
        public async Task GetAsync_ReturnsOkObjectResult_WithClienteDto()
        {
            // Arrange
            var mockRepository = new Mock<IRepositorio<Cliente>>();
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "John Doe",
                Direccion = "123 Main St",
                Edad = 30,
                Identificacion = "123456789",
                Password = "password",
                Telefono = "555-555-5555",
                Genero = "Male"
            };
            mockRepository.Setup(repo => repo.GetAsync(1)).ReturnsAsync(cliente);
            var controller = new ClienteController(mockRepository.Object);

            // Act
            var result = await controller.GetAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var clienteResult = Assert.IsType<ClienteDto>(okResult.Value);
            Assert.Equal(cliente.ToDto(), clienteResult);
        }
    }
}

