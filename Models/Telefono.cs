namespace Practica_Evaluada_1.Models
{
    /// <summary>
    /// Modelo simple para representar un numero de telefono asociado a un cliente.
    /// Se deja separado de Cliente para que luego el grupo pueda agregar, editar o
    /// eliminar telefonos sin mezclar esa logica con los datos principales del cliente.
    /// </summary>
    public class Telefono
    {
        public int Id { get; set; }

        public string Numero { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;
    }
}
