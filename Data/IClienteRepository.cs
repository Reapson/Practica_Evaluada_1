using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    /// <summary>
    /// Contrato de acceso a datos para clientes.
    /// Esta interfaz permite cumplir la estructura por capas: el controlador no
    /// consulta directamente una base de datos ni una lista en memoria.
    /// </summary>
    public interface IClienteRepository
    {
        List<Cliente> ObtenerTodos();

        Cliente? ObtenerPorId(int id);

        void Registrar(Cliente cliente);

        void Modificar(Cliente cliente);

        void Borrar(int id);
    }
}
