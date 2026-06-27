using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    public interface IVehiculoRepository
    {
        List<Vehiculo> ObtenerTodos();

        Vehiculo? ObtenerPorId(int id);

        Vehiculo? ObtenerPorPlaca(string placa);

        void Registrar(Vehiculo vehiculo);

        void Modificar(Vehiculo vehiculo);

        void Borrar(int id);
    }
}
