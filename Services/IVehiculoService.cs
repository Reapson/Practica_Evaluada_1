using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    public interface IVehiculoService
    {
        List<Vehiculo> ObtenerVehiculos();

        Vehiculo? ObtenerVehiculoPorId(int id);

        string? RegistrarVehiculo(Vehiculo vehiculo);

        string? ModificarVehiculo(Vehiculo vehiculo);

        void BorrarVehiculo(int id);
    }
}
