using Usuario.Dtos;

namespace Usuario.Servicios
{
    public interface IServicioTransacciones
    {
        Task<ICollection<ReportDto>> Reporte(int id, DateTime initDate, DateTime endDate);
        Task<string> TransaccionAsync(MovimientoDto dto);
    }
}