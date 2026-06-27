using Practica_Evaluada_1.Data;
using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IClienteRepository _clienteRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository, IClienteRepository clienteRepository)
        {
            _vehiculoRepository = vehiculoRepository;
            _clienteRepository = clienteRepository;
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            var vehiculos = _vehiculoRepository.ObtenerTodos();

            foreach (var vehiculo in vehiculos)
            {
                vehiculo.Cliente = _clienteRepository.ObtenerPorId(vehiculo.ClienteId);
            }

            return vehiculos;
        }

        public Vehiculo? ObtenerVehiculoPorId(int id)
        {
            var vehiculo = _vehiculoRepository.ObtenerPorId(id);

            if (vehiculo is not null)
            {
                vehiculo.Cliente = _clienteRepository.ObtenerPorId(vehiculo.ClienteId);
            }

            return vehiculo;
        }

        public string? RegistrarVehiculo(Vehiculo vehiculo)
        {
            var validacion = ValidarVehiculo(vehiculo);

            if (validacion is not null)
            {
                return validacion;
            }

            _vehiculoRepository.Registrar(vehiculo);
            return null;
        }

        public string? ModificarVehiculo(Vehiculo vehiculo)
        {
            var validacion = ValidarVehiculo(vehiculo);

            if (validacion is not null)
            {
                return validacion;
            }

            _vehiculoRepository.Modificar(vehiculo);
            return null;
        }

        public void BorrarVehiculo(int id)
        {
            _vehiculoRepository.Borrar(id);
        }

        private string? ValidarVehiculo(Vehiculo vehiculo)
        {
            if (_clienteRepository.ObtenerPorId(vehiculo.ClienteId) is null)
            {
                return "Debe seleccionar un cliente valido para el vehiculo.";
            }

            var vehiculoConMismaPlaca = _vehiculoRepository.ObtenerPorPlaca(vehiculo.Placa);

            if (vehiculoConMismaPlaca is not null && vehiculoConMismaPlaca.Id != vehiculo.Id)
            {
                return "Un vehiculo no puede tener 2 clientes.";
            }

            return null;
        }
    }
}
