using System.ComponentModel.DataAnnotations;

namespace Practica_Evaluada_1.Models
{
    /// <summary>
    /// ViewModel usado por los formularios de registrar y modificar.
    /// Se separa del modelo Cliente para mantener las validaciones de pantalla
    /// fuera de la entidad principal del sistema.
    /// </summary>
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La cedula es requerida.")]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre completo es requerido.")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electronico es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico valido.")]
        [Display(Name = "Correo electronico")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Required(ErrorMessage = "La direccion es requerida.")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; } = string.Empty;

        public List<TelefonoViewModel> Telefonos { get; set; } = new()
        {
            new TelefonoViewModel()
        };

        public Cliente ConvertirACliente()
        {
            return new Cliente
            {
                Id = Id,
                Cedula = Cedula,
                NombreCompleto = NombreCompleto,
                CorreoElectronico = CorreoElectronico,
                Direccion = Direccion,
                Telefonos = Telefonos
                    .Where(telefono => !string.IsNullOrWhiteSpace(telefono.Numero))
                    .Select(telefono => new Telefono
                    {
                        Id = telefono.Id,
                        Numero = telefono.Numero,
                        Tipo = telefono.Tipo
                    })
                    .ToList()
            };
        }

        public static ClienteViewModel DesdeCliente(Cliente cliente)
        {
            return new ClienteViewModel
            {
                Id = cliente.Id,
                Cedula = cliente.Cedula,
                NombreCompleto = cliente.NombreCompleto,
                CorreoElectronico = cliente.CorreoElectronico,
                Direccion = cliente.Direccion,
                Telefonos = cliente.Telefonos.Count == 0
                    ? new List<TelefonoViewModel> { new TelefonoViewModel() }
                    : cliente.Telefonos.Select(telefono => new TelefonoViewModel
                    {
                        Id = telefono.Id,
                        Numero = telefono.Numero,
                        Tipo = telefono.Tipo
                    }).ToList()
            };
        }
    }
}
