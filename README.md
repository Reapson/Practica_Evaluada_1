# Practica Evaluada 1

Practica Evaluada #1 del curso Programacion Avanzada Web.

## Integrantes del grupo

- Reapson Anticona Corrales
- Israel Martinez Loaisiga
- Lucas Chavarria Lopez
- Jostin Mason Herrera

## Repositorio

[Reapson/Practica_Evaluada_1.git](https://github.com/Reapson/Practica_Evaluada_1.git)

## Especificacion basica del proyecto

### Arquitectura del proyecto

El proyecto utiliza ASP.NET Core MVC en .NET 8 y se organiza en capas basicas:

- Controllers: reciben las solicitudes del usuario y devuelven las vistas.
- Views: contienen las pantallas Razor del sistema.
- Models: representan las entidades Cliente y Telefono.
- Services: capa logica de negocio. Actualmente contiene la logica para obtener el listado de clientes.
- Data: capa de acceso a datos. Actualmente usa una lista en memoria para simular los datos.

### Libraries o paquetes NuGet utilizados

No se agregaron paquetes NuGet externos. Se utilizan las librerias incluidas por defecto en ASP.NET Core MVC.

### Principios SOLID y patrones utilizados

- Responsabilidad unica: los modelos, servicios, repositorios y controladores tienen responsabilidades separadas.
- Inversion de dependencias: el controlador depende de IClienteService y el servicio depende de IClienteRepository.
- Inyeccion de dependencias: las implementaciones se registran en Program.cs para desacoplar las capas.
- Patron Repository: IClienteRepository y ClienteRepository separan el acceso a datos de la logica de negocio.

## Alcance desarrollado en este avance

Se desarrollo la base del proyecto y el listado de clientes con sus numeros de telefono.

Queda pendiente para los companeros:

- Ver detalle de cliente.
- Registrar cliente y agregar N numeros de telefono.
- Modificar cliente y sus telefonos.
- Borrar cliente y sus telefonos ligados.
