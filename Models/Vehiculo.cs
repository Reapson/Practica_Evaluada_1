namespace Practica_Evaluada_1.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        public string Placa { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;

        public string Modelo { get; set; } = string.Empty;

        public int Anio { get; set; }

        public string Color { get; set; } = string.Empty;

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
