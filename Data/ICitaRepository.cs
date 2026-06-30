using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    public interface ICitaRepository
    {
        List<Cita> ObtenerTodos();

        Cita? ObtenerPorId(int id);

        void Registrar(Cita cita);

        void Modificar(Cita cita);

        void Borrar(int id);
    }
}