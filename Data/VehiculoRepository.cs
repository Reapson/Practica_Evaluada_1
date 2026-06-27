using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly List<Vehiculo> _vehiculos = new()
        {
            new Vehiculo
            {
                Id = 1,
                Placa = "ABC123",
                Marca = "Mercedes-Benz",
                Modelo = "Clase C",
                Anio = 2022,
                Color = "Negro",
                ClienteId = 1
            },
            new Vehiculo
            {
                Id = 2,
                Placa = "LUX456",
                Marca = "BMW",
                Modelo = "Serie 5",
                Anio = 2023,
                Color = "Blanco",
                ClienteId = 2
            }
        };

        public List<Vehiculo> ObtenerTodos()
        {
            return _vehiculos;
        }

        public Vehiculo? ObtenerPorId(int id)
        {
            return _vehiculos.FirstOrDefault(vehiculo => vehiculo.Id == id);
        }

        public Vehiculo? ObtenerPorPlaca(string placa)
        {
            return _vehiculos.FirstOrDefault(vehiculo =>
                string.Equals(vehiculo.Placa, placa.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public void Registrar(Vehiculo vehiculo)
        {
            vehiculo.Id = ObtenerSiguienteVehiculoId();
            _vehiculos.Add(vehiculo);
        }

        public void Modificar(Vehiculo vehiculo)
        {
            var vehiculoActual = ObtenerPorId(vehiculo.Id);

            if (vehiculoActual is null)
            {
                return;
            }

            vehiculoActual.Placa = vehiculo.Placa;
            vehiculoActual.Marca = vehiculo.Marca;
            vehiculoActual.Modelo = vehiculo.Modelo;
            vehiculoActual.Anio = vehiculo.Anio;
            vehiculoActual.Color = vehiculo.Color;
            vehiculoActual.ClienteId = vehiculo.ClienteId;
        }

        public void Borrar(int id)
        {
            var vehiculo = ObtenerPorId(id);

            if (vehiculo is not null)
            {
                _vehiculos.Remove(vehiculo);
            }
        }

        private int ObtenerSiguienteVehiculoId()
        {
            return _vehiculos.Count == 0 ? 1 : _vehiculos.Max(vehiculo => vehiculo.Id) + 1;
        }
    }
}
