namespace Usuario.Dtos
{
        public record ClienteDto( int id, string nombre, string genero, int edad, string identificacion, string direccion, string telefono, string password, bool estado);
        public record createClienteDto(string nombre, string genero, int edad, string identificacion, string direccion, string telefono, string password, bool estado);
        public record updateClienteDto(string nombre, string genero, int edad, string identificacion, string direccion, string telefono, string password, bool estado);
        public record CuentaDto( string numero, string tipo, double saldo, bool estado, int clienteId);
        public record MovimientoDto( string tipo, string tipoCuenta, double valor, double saldo, DateTime fecha, int cuentaId);
        public record ReportDto(string cuentaTipo, double valor, double saldo, DateTime fecha, int cuentaId, string Nombrecliente);
}

//v( string cuentaTipo, double valor, double saldo, DateTime fecha, int cuentaId, string Nombrecliente)
