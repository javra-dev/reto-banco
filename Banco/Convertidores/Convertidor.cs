using Usuario.Dtos;
using Usuario.Models;

namespace Usuario.Convertidores
{
    public static class Convertidor
    {
        public static ClienteDto ToDto (this Cliente entidad)
        {
            return new ClienteDto(entidad.Id,
                entidad.Nombre,
                entidad.Genero,
                entidad.Edad,
                entidad.Identificacion,
                entidad.Telefono,
                entidad.Direccion,
                entidad.Password,
                entidad.Estado);         
        }

        public static CuentaDto ToDto(this Cuenta entidad)
        {
            return new CuentaDto(
                entidad.Numero,
                entidad.Tipo,
                entidad.Saldo,
                entidad.Estado,
                entidad.ClienteId);
        }

        public static MovimientoDto ToDto( this Movimiento mov)
        {
            return new MovimientoDto(
                mov.Tipo,
                mov.TipoCuenta,
                mov.Valor,
                mov.Saldo,
                mov.Fecha,
                mov.CuentaID);
        }
    }
}
