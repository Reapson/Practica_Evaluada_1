using Practica_Evaluada_1.Data;
using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVehiculoRepository _vehiculoRepository;

        public CitaService(
            ICitaRepository citaRepository,
            IClienteRepository clienteRepository,
            IVehiculoRepository vehiculoRepository)
        {
            _citaRepository = citaRepository;
            _clienteRepository = clienteRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        public List<Cita> ObtenerCitas()
        {
            var citas = _citaRepository.ObtenerTodos();

            foreach (var cita in citas)
            {
                cita.Cliente = _clienteRepository.ObtenerPorId(cita.ClienteId);
                cita.Vehiculo = _vehiculoRepository.ObtenerPorId(cita.VehiculoId);
            }

            return citas;
        }

        public Cita? ObtenerCitaPorId(int id)
        {
            return _citaRepository.ObtenerPorId(id);
        }

        public void RegistrarCita(Cita cita)
        {
            _citaRepository.Registrar(cita);
        }

        public void ModificarCita(Cita cita)
        {
            _citaRepository.Modificar(cita);
        }

        public void BorrarCita(int id)
        {
            _citaRepository.Borrar(id);
        }
    }
}