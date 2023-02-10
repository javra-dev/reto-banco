using Microsoft.AspNetCore.Mvc;
using Usuario.Convertidores;
using Usuario.Dtos;
using Usuario.Models;
using Usuario.Servicios;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("Movimientos")]
    public class MovimientoController : Controller
    {
        private readonly IRepositorio<Movimiento> _repository;
        private readonly IServicioTransacciones _servicio;

        public MovimientoController(IRepositorio<Movimiento> repository, IServicioTransacciones servicio)
        {
            _repository = repository;
            _servicio = servicio;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoDto>>> GetAllAsync()
        {

            var movs = await _repository.GetAllAsync();

            return Ok(movs.Select(x => x.ToDto()));
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<MovimientoDto>>> GetAsync(int id)
        {

            var mov = await _repository.GetAsync(id);

            return Ok(mov.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(MovimientoDto movDto)
        {
           
            var result = _servicio.TransaccionAsync(movDto).Result;
            
            return Content(result);
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
        public async Task<ActionResult> PutAsync(int id, MovimientoDto movDto)
        {
            var item = await _repository.GetAsync(id);

            if (item == null) return NotFound();

            item.Valor = movDto.valor;
            item.Tipo = movDto.tipo;
            item.Saldo = movDto.saldo;

            await _repository.UpdateAsync(item);

            return NoContent();
        }

        [HttpGet("reporte")]
        public async Task<ActionResult<ICollection<ReportDto>>> GetReport(int clienteId, DateTime inicio, DateTime fin)
        {
            var report = await _servicio.Reporte(clienteId, inicio, fin);

            return Ok(report);
        }
    }
}
