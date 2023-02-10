using System.Linq.Expressions;
using Usuario.Dtos;
using Usuario.Models;

namespace Usuario.Servicios
{
    public class ServicioTransacciones : IServicioTransacciones
    {

        private readonly IRepositorio<Movimiento> repoMovimiento;
        private readonly IRepositorio<Cuenta> repoCuenta;
        private readonly IRepositorio<Cliente> repoCliente;

        public ServicioTransacciones(IRepositorio<Movimiento> movimiento,
                                     IRepositorio<Cuenta> cuenta,
                                     IRepositorio<Cliente> cliente)
        {
            repoMovimiento = movimiento;
            repoCuenta = cuenta;
            repoCliente = cliente;
        }

        public async Task<string> TransaccionAsync(MovimientoDto dto)
        {
            var cuenta = repoCuenta.GetAsync(dto.cuentaId).Result;

            var movimiento = new Movimiento();
            movimiento.Tipo = dto.valor < 0 ? "Retiro" : "Deposito";


            movimiento.Fecha = DateTime.Now;
            movimiento.Valor = dto.valor;
            movimiento.Saldo = dto.valor + cuenta.Saldo;

            if (movimiento.Saldo < 0)
                return $"Saldo insuficiente para realizar la transaccion";
            
            movimiento.TipoCuenta = cuenta.Tipo;
            movimiento.Cuenta = cuenta;
            movimiento.CuentaID = dto.cuentaId;

            cuenta.Saldo = movimiento.Saldo;
            await repoCuenta.UpdateAsync(cuenta);
            await repoMovimiento.CreateAsync(movimiento);

            return $"Se realizó un {movimiento.Tipo} por un valor de {movimiento.Valor}";
        }

        public async Task<ICollection<ReportDto>> Reporte(int id, DateTime initDate, DateTime endDate)
        {

            Expression<Func<Cuenta, bool>> filterCuenta = c => c.ClienteId == id;
            var clienteCuenta = await repoCliente.GetAsync(id);

            var cuentas = await repoCuenta.GetAllAsync(filterCuenta);

            var idsCuenta = cuentas.Select(c => c.Id).ToList();

            Expression<Func<Movimiento, bool>> filterMovimiento = m => idsCuenta.Contains(m.CuentaID)
                                                                    && m.Fecha > initDate
                                                                    && m.Fecha < endDate;

            var movimientos = await repoMovimiento.GetAllAsync(filterMovimiento);

            var reporteDtos = movimientos.Select(x => new ReportDto
            (x.TipoCuenta,
             x.Valor,
             x.Saldo,
             x.Fecha,
             x.CuentaID,
             clienteCuenta.Nombre)).ToList();

            return reporteDtos;
        }
    }
}
