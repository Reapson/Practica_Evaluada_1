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

        // TODO: Companeros, agregar aqui los contratos necesarios para:
        // ObtenerPorId, Registrar, Modificar y Borrar clientes.
    }
}
