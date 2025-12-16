# ✈️ Sistema de Gestión de Vuelos

Este proyecto es una aplicación Full-Stack desarrollada en el ecosistema .NET, diseñada para la gestión integral de reservas de vuelos, aeropuertos y pasajeros.

## 🏗 Arquitectura del Sistema

La solución sigue una arquitectura Cliente-Servidor desacoplada, dividida en tres proyectos principales para garantizar la separación de responsabilidades (SoC) y la reutilización de código.

### 🛠 Stack Tecnológico

| Capa | Tecnología | Descripción |
| :--- | :--- | :--- |
| Frontend | Blazor WebAssembly | Interfaz de usuario reactiva basada en componentes Razor. |
| Backend | ASP.NET Core Web API | API RESTful que gestiona la lógica de negocio. |
| Base de Datos | SQL Server + EF Core | Persistencia de datos mediante ORM (Code-First). |
| Común | .NET Standard Library | Biblioteca de clases compartida (Modelos y DTOs). |

---

## 📂 Estructura de la Solución

La estructura del código fuente se organiza en los siguientes proyectos:

### 1. 🖥️ Vuelos.Client (Frontend)
Es la capa de presentación que se ejecuta en el navegador del usuario. Se encarga de la UI y del consumo de la API.

* Tecnología: Blazor.
* Páginas Principales (Pages/):
    * Home.razor: Página de bienvenida.
    * ListarVuelos.razor: Catálogo para visualizar vuelos disponibles.
    * CrearReserva.razor: Formulario para el registro de nuevas reservas.
    * ListarReservas.razor: Panel de gestión de reservas del usuario.
* Responsabilidad: Renderizado, validación de formularios en cliente y llamadas HTTP.

### 2. ⚙️ Vuelos.API (Backend)
Es el núcleo lógico del sistema. Expone los datos y procesa las transacciones.

* Tecnología: ASP.NET Core Web API.
* Componentes Clave:
    * Controllers:
        * VueloController.cs: Endpoints para gestión y búsqueda de vuelos.
        * ReservaController.cs: Endpoints para crear y listar reservas.
    * Data:
        * VuelosContext.cs: Contexto de base de datos (Entity Framework Core).
        * Migrations/: Historial de cambios en el esquema de base de datos.
* Responsabilidad: Lógica de negocio, acceso a datos y seguridad.

### 3. 📦 Vuelos.Shared (Biblioteca Compartida)
Biblioteca transversal utilizada tanto por el Cliente como por la API para asegurar la consistencia de los tipos de datos.

* Contenido:
    * Entidades (Entities): Vuelo, Reserva, Aeropuerto.
    * DTOs (Data Transfer Objects):
        * VueloDto: Para transferencia ligera de datos de vuelos.
        * ReservaDto: Para la creación y lectura de reservas.
        * DashboardDto: Para visualización de métricas o resúmenes.

---

## 📊 Diagramas de Arquitectura

### Diagrama de Arquitectura

<div align=center>

|![Diagrama de Arquitectura](/diagramasUML/arquitectura.png)|
|-|
|Código fuente: [arquitectura.puml](/diagramasUML/arquitectura.puml)|

</div>

### Diagrama de Biblioteca

<div align=center>

|![Diagrama de Biblioteca](/diagramasUML/biblioteca.png)|
|-|
|Código fuente: [biblioteca.puml](/diagramasUML/biblioteca.puml)|

</div>

### Diagrama de Estructura del Código

<div align=center>

|![Diagrama de Estructura del Código](/diagramasUML/estructuraCodigo.png)|
|-|
|Código fuente: [estructuraCodigo.puml](/diagramasUML/estructuraCodigo.puml)|

</div>