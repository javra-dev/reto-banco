using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Usuario.Convertidores;
using Usuario.Dtos;
using Usuario.Models;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class CuentaController : Controller
    {
        private readonly IRepositorio<Cuenta> _repository;
        public CuentaController(IRepositorio<Cuenta> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaDto>>> GetAllAsync()
        {
            var cuentas = await _repository.GetAllAsync();

            return Ok(cuentas.Select(x => x.ToDto()));
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<CuentaDto>>> GetAsync(int id)
        {
            //if (userId == null) return BadRequest();


            var cuenta = await _repository.GetAsync(id);

            return Ok(cuenta.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(CuentaDto cuentaDto)
        {
            if (cuentaDto != null)
            {
                var cuentaNueva = new Cuenta
                {
                    Numero = cuentaDto.numero,
                    Tipo = cuentaDto.tipo,
                    Saldo = cuentaDto.saldo,
                    Estado = cuentaDto.estado,
                    ClienteId = cuentaDto.clienteId
                };

                await _repository.CreateAsync(cuentaNueva);
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
        public async Task<ActionResult> PutAsync(int id, CuentaDto updateDto)
        {
            var item = await _repository.GetAsync(id);

            if (item == null) return NotFound();

            item.Numero = updateDto.numero;
            item.Tipo = updateDto.tipo;
            item.Saldo = updateDto.saldo;
            item.Estado = updateDto.estado;

            await _repository.UpdateAsync(item);

            return NoContent();
        }

    }
}
