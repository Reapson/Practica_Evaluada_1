using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    /// <summary>
    /// Contrato de la capa logica de negocio para clientes.
    /// Desde aqui se deberian aplicar validaciones y reglas antes de enviar o recibir
    /// informacion desde la capa de acceso a datos.
    /// </summary>
    public interface IClienteService
    {
        List<Cliente> ObtenerClientes();

        Cliente? ObtenerClientePorId(int id);

        void RegistrarCliente(Cliente cliente);

        void ModificarCliente(Cliente cliente);

        void BorrarCliente(int id);
    }
}
