namespace Practica_Evaluada_1.Models
{
    /// <summary>
    /// Modelo principal del sistema. Representa los datos basicos de un cliente y
    /// contiene la lista de telefonos solicitada en el enunciado de la practica.
    /// </summary>
    public class Cliente
    {
        public int Id { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string NombreCompleto { get; set; } = string.Empty;

        public string CorreoElectronico { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public List<Telefono> Telefonos { get; set; } = new();
    }
}
