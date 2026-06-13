using Practica_Evaluada_1.Data;
using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    /// <summary>
    /// Capa logica de negocio para clientes.
    /// En este primer avance solo se implementa el listado porque es el tercio
    /// asignado. Las demas reglas del CRUD deben agregarse en esta clase.
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
    }
}
