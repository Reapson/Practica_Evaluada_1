using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    public class CitaRepository : ICitaRepository
    {
        private readonly List<Cita> _citas = new()
        {
            new Cita
            {
                Id = 1,
                ClienteId = 1,
                VehiculoId = 1,
                FechaCita = DateTime.Now.AddDays(1),
                Estado = "Ingresada"
            }
        };

        public List<Cita> ObtenerTodos()
        {
            return _citas;
        }

        public Cita? ObtenerPorId(int id)
        {
            return _citas.FirstOrDefault(c => c.Id == id);
        }

        public void Registrar(Cita cita)
        {
            cita.Id = ObtenerSiguienteId();
            _citas.Add(cita);
        }

        public void Modificar(Cita cita)
        {
            var actual = ObtenerPorId(cita.Id);

            if (actual == null)
                return;

            actual.ClienteId = cita.ClienteId;
            actual.VehiculoId = cita.VehiculoId;
            actual.FechaCita = cita.FechaCita;
            actual.Estado = cita.Estado;
        }

        public void Borrar(int id)
        {
            var cita = ObtenerPorId(id);

            if (cita != null)
                _citas.Remove(cita);
        }

        private int ObtenerSiguienteId()
        {
            return _citas.Count == 0
                ? 1
                : _citas.Max(c => c.Id) + 1;
        }
    }
}