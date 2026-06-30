using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Services
{
    public interface ICitaService
    {
        List<Cita> ObtenerCitas();

        Cita? ObtenerCitaPorId(int id);

        void RegistrarCita(Cita cita);

        void ModificarCita(Cita cita);

        void BorrarCita(int id);
    }
}