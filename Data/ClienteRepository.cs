using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    /// <summary>
    /// Implementacion temporal de acceso a datos usando una lista en memoria.
    /// Para este primer avance permite mostrar el listado sin configurar base de datos.
    /// Luego se puede reemplazar esta clase por Entity Framework, SQL Server u otro
    /// mecanismo de persistencia manteniendo el mismo contrato IClienteRepository.
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes = new()
        {
            new Cliente
            {
                Id = 1,
                Cedula = "1-1111-1111",
                NombreCompleto = "Maria Fernandez Solis",
                CorreoElectronico = "maria.fernandez@correo.com",
                Direccion = "San Jose, Costa Rica",
                Telefonos =
                {
                    new Telefono { Id = 1, Numero = "8888-1111", Tipo = "Celular" },
                    new Telefono { Id = 2, Numero = "2222-1111", Tipo = "Casa" }
                }
            },
            new Cliente
            {
                Id = 2,
                Cedula = "2-2222-2222",
                NombreCompleto = "Carlos Mora Vargas",
                CorreoElectronico = "carlos.mora@correo.com",
                Direccion = "Heredia, Costa Rica",
                Telefonos =
                {
                    new Telefono { Id = 3, Numero = "8777-2222", Tipo = "Celular" }
                }
            },
            new Cliente
            {
                Id = 3,
                Cedula = "3-3333-3333",
                NombreCompleto = "Ana Rojas Castro",
                CorreoElectronico = "ana.rojas@correo.com",
                Direccion = "Alajuela, Costa Rica",
                Telefonos =
                {
                    new Telefono { Id = 4, Numero = "8666-3333", Tipo = "Celular" },
                    new Telefono { Id = 5, Numero = "2444-3333", Tipo = "Trabajo" }
                }
            }
        };

        public List<Cliente> ObtenerTodos()
        {
            return _clientes;
        }
    }
}
