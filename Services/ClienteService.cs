using Practica_Evaluada_1.Data;
using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    /// <summary>
    /// Capa logica de negocio para clientes.
    /// Aqui se centralizan las reglas basicas antes de enviar la informacion
    /// hacia la capa de acceso a datos.
    /// </summary>
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clienteRepository.ObtenerTodos();
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            return _clienteRepository.ObtenerPorId(id);
        }

        public void RegistrarCliente(Cliente cliente)
        {
            cliente.Telefonos = LimpiarTelefonosVacios(cliente.Telefonos);
            _clienteRepository.Registrar(cliente);
        }

        public void ModificarCliente(Cliente cliente)
        {
            cliente.Telefonos = LimpiarTelefonosVacios(cliente.Telefonos);
            _clienteRepository.Modificar(cliente);
        }

        public void BorrarCliente(int id)
        {
            _clienteRepository.Borrar(id);
        }

        private List<Telefono> LimpiarTelefonosVacios(List<Telefono> telefonos)
        {
            return telefonos
                .Where(telefono => !string.IsNullOrWhiteSpace(telefono.Numero))
                .ToList();
        }
    }
}
