# Sales Date Prediction

Una plataforma web API que tiene como objetivo crear órdenes y predecir cuándo ocurrirá la próxima orden por cliente de acuerdo con los registros almacenados en la base de datos.

## Tabla de Contenidos

- [Descripción](#descripción)
- [Requisitos Previos](#requisitos-previos)
- [Instalación](#instalación)
  - [Clonar el Repositorio](#clonar-el-repositorio)
  - [Base de Datos](#base-de-datos)
  - [Backend](#backend)
  - [Frontend Angular](#frontend-angular)
  - [Frontend Vanilla JS](#frontend-vanilla-js)
- [Ejecución de la Prueba](#ejecución-de-la-prueba)
- [Información Adicional](#información-adicional)

---

## Descripción

Este proyecto está desarrollado en .NET 8.0 utilizando una arquitectura de microservicios. Se han creado tres servicios independientes:

1. **HR**: Gestiona la información de los empleados.
2. **Production**: Gestiona la información de los productos.
3. **Sales**: Administra las órdenes y la predicción de las órdenes.

Además, se implementó un **API Gateway** para facilitar la comunicación entre los servicios.

El proyecto incluye dos frontends:  
- **Angular**: Interactúa con los microservicios para la gestión de órdenes.  
- **Vanilla JS**: Proyecto simple utilizando D3.js para visualizaciones.  

---

## Requisitos Previos

- [.NET SDK](https://dotnet.microsoft.com/download) (versión recomendada: 8.0 o superior)
- [Node.js](https://nodejs.org/) (para ejecutar el proyecto en Angular)
- [SQL Server](https://www.microsoft.com/sql-server) (para la base de datos)

---

## Instalación

### Clonar el Repositorio

Clona el repositorio del proyecto:

```bash
git clone https://github.com/cruzrom21/SalesDatePrediction.git
```

---

## Base de Datos

Los scripts de base de datos están diseñados para SQL Server y se encuentran en la carpeta ScriptsDB.

- Incluyen la creación de procedimientos almacenados y vistas.
- Solo las vistas son necesarias para que funcione el API en .NET.
- No hay un orden específico para la ejecución de los scripts.

Para ejecutar las vistas:

1. Abre SQL Server Management Studio.
2. Conéctate a tu instancia de SQL Server.
3. Ejecuta los scripts de vistas en la base de datos correspondiente.

---

## Backend
