using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Convertidores;
using Usuario.Dtos;
using Usuario.Models;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IRepositorio<Cliente> _repository;
        public ClienteController(IRepositorio<Cliente> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAllAsync()
        {
            
            var cliente = await _repository.GetAllAsync();
            
            return Ok(cliente.Select(x => x.ToDto()));
        }

        [HttpGet("userId")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAsync(int userId)
        {
            //if (userId == null) return BadRequest();

            
            var cliente = await _repository.GetAsync(userId);
            
            return Ok(cliente.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(createClienteDto clienteDto)
        {
            if (clienteDto != null)
            {
                var clientenuevo = new Cliente
                {
                    Nombre = clienteDto.nombre,
                    Direccion = clienteDto.direccion,
                    Edad = clienteDto.edad,
                    Identificacion = clienteDto.identificacion,
                    Password = clienteDto.password,
                    Telefono = clienteDto.telefono,
                    Genero = clienteDto.genero
                };
                
                await _repository.CreateAsync(clientenuevo);
            }
            
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var item = await _repository.GetAsync(id);

            if (item == null) return NotFound();

            await _repository.RemoveAsync(item.Id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, updateClienteDto updateDto)
        {
            var item = await _repository.GetAsync(id);

            if (item == null) return NotFound();

            item.Nombre = updateDto.nombre;
            item.Genero = updateDto.genero;
            item.Direccion = updateDto.direccion;
            item.Edad = updateDto.edad;
            item.Identificacion = updateDto.identificacion;
            item.Password = updateDto.password;
            item.Telefono = updateDto.telefono;
            item.Estado = updateDto.estado;

            await _repository.UpdateAsync(item);

            return NoContent();
        }

    }
}
