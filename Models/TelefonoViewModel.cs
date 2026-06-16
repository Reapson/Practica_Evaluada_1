using System.ComponentModel.DataAnnotations;

namespace Practica_Evaluada_1.Models
{
    /// <summary>
    /// ViewModel para capturar telefonos desde los formularios.
    /// </summary>
    public class TelefonoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; } = string.Empty;

        [Display(Name = "Tipo")]
        public string Tipo { get; set; } = "Celular";
    }
}
