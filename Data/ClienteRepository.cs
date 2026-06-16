using Practica_Evaluada_1.Models;

namespace Practica_Evaluada_1.Data
{
    /// <summary>
    /// Implementacion de acceso a datos usando una lista en memoria.
    /// Permite cumplir la practica sin configurar base de datos.
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

        public Cliente? ObtenerPorId(int id)
        {
            return _clientes.FirstOrDefault(cliente => cliente.Id == id);
        }

        public void Registrar(Cliente cliente)
        {
            cliente.Id = ObtenerSiguienteClienteId();
            AsignarIdsTelefonos(cliente);
            _clientes.Add(cliente);
        }

        public void Modificar(Cliente cliente)
        {
            var clienteActual = ObtenerPorId(cliente.Id);

            if (clienteActual is null)
            {
                return;
            }

            clienteActual.Cedula = cliente.Cedula;
            clienteActual.NombreCompleto = cliente.NombreCompleto;
            clienteActual.CorreoElectronico = cliente.CorreoElectronico;
            clienteActual.Direccion = cliente.Direccion;
            clienteActual.Telefonos = cliente.Telefonos;

            AsignarIdsTelefonos(clienteActual);
        }

        public void Borrar(int id)
        {
            var cliente = ObtenerPorId(id);

            if (cliente is not null)
            {
                _clientes.Remove(cliente);
            }
        }

        private int ObtenerSiguienteClienteId()
        {
            return _clientes.Count == 0 ? 1 : _clientes.Max(cliente => cliente.Id) + 1;
        }

        private int ObtenerSiguienteTelefonoId()
        {
            var telefonos = _clientes.SelectMany(cliente => cliente.Telefonos).ToList();
            return telefonos.Count == 0 ? 1 : telefonos.Max(telefono => telefono.Id) + 1;
        }

        private void AsignarIdsTelefonos(Cliente cliente)
        {
            var siguienteId = ObtenerSiguienteTelefonoId();

            foreach (var telefono in cliente.Telefonos)
            {
                if (telefono.Id == 0)
                {
                    telefono.Id = siguienteId;
                    siguienteId++;
                }
            }
        }
    }
}
