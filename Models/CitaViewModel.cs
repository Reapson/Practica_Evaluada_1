using System.ComponentModel.DataAnnotations;

namespace Practica_Evaluada_1.Models
{
    public class CitaViewModel
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un vehiculo.")]
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es requerida.")]
        [Display(Name = "Fecha y hora")]
        public DateTime FechaCita { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El estado es requerido.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Ingresada";

        public Cita ConvertirACita()
        {
            return new Cita
            {
                Id = Id,
                ClienteId = ClienteId,
                VehiculoId = VehiculoId,
                FechaCita = FechaCita,
                Estado = Estado.Trim()
            };
        }

        public static CitaViewModel DesdeCita(Cita cita)
        {
            return new CitaViewModel
            {
                Id = cita.Id,
                ClienteId = cita.ClienteId,
                VehiculoId = cita.VehiculoId,
                FechaCita = cita.FechaCita,
                Estado = cita.Estado
            };
        }
    }
}
