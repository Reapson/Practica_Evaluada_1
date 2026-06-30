namespace Practica_Evaluada_1.Models
{
	public class Cita
	{
		public int Id { get; set; }

		public int ClienteId { get; set; }

		public Cliente? Cliente { get; set; }

		public int VehiculoId { get; set; }

		public Vehiculo? Vehiculo { get; set; }

		public DateTime FechaCita { get; set; }

		public string Estado { get; set; } = "Ingresada";
	}
}