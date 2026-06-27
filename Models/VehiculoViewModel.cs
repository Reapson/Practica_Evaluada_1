using System.ComponentModel.DataAnnotations;

namespace Practica_Evaluada_1.Models
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La placa es requerida.")]
        [Display(Name = "Placa")]
        public string Placa { get; set; } = string.Empty;

        [Required(ErrorMessage = "La marca es requerida.")]
        [Display(Name = "Marca")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es requerido.")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; } = string.Empty;

        [Range(1900, 2100, ErrorMessage = "El anio debe estar entre 1900 y 2100.")]
        [Display(Name = "Anio")]
        public int Anio { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage = "El color es requerido.")]
        [Display(Name = "Color")]
        public string Color { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public Vehiculo ConvertirAVehiculo()
        {
            return new Vehiculo
            {
                Id = Id,
                Placa = Placa.Trim().ToUpperInvariant(),
                Marca = Marca.Trim(),
                Modelo = Modelo.Trim(),
                Anio = Anio,
                Color = Color.Trim(),
                ClienteId = ClienteId
            };
        }

        public static VehiculoViewModel DesdeVehiculo(Vehiculo vehiculo)
        {
            return new VehiculoViewModel
            {
                Id = vehiculo.Id,
                Placa = vehiculo.Placa,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                Color = vehiculo.Color,
                ClienteId = vehiculo.ClienteId
            };
        }
    }
}
