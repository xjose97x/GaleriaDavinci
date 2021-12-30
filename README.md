# Galeria Davinci
<img width="300" src="https://www.udla.edu.ec/clubes/wp-content/uploads/2021/07/udla_logo_blanco.png" />

### Materia: Programación IV
### Integrantes: Francisco Basantes, José I. Escudero, Christian Samaniego

## Descripción
La galería de arte DaVinci busca digitalizar su negocio para tener un mayor alcance. Para ello se requiere desarrollar una página web en la cual los visitantes puedan tener una vista general de todas las obras que disponen en el momento. Dicha página web debe mostrar las obras de arte que se encuentren en una base de datos, y debe permitir al usuario hacer clic en ella para ver más detalles.

El alcance del proyecto incluye el desarrollo de una página web en tecnologías .NET utilizando el patrón MVC. El proyecto inicialmente permitirá la autenticación de autores de obra de arte con el objetivo de que puedan gestionar las obras que se mostraran en la galería. Además de ello, permitirá a los otros usuarios dejar una calificación a las obras de arte en la galería. Posteriormente, se desarrollara una aplicación para escritorio utilizando la tecnología UWP y una aplicación móvil utilizando Xamarin que brindara funcionalidades similares a la aplicación web.


## Requerimientos:
- Version Minima Sistema Operativo para UWP: Windows 10, Version 1809 (10.0; Build 17763)
- .NET 5.
- Microsoft SQL Server

## Instrucciones:
- Instalar paquetes NuGet (Visual Studio 2019 lo hace automaticamente)
- Ejecutar migraciones (en caso de hacerlo por linea de comando, revisar la seccion de "Migraciones" abajo)
- Configurar la conexion a la base de datos (ConnectionString) en `appsettings.json`.
- Configurar el API Key de Sendgrid en `appsettings.json`. Por favor solicitar el API Key al equipo.
- En caso de usar Visual Studio, configurar para ejecutar el proyecto UWP y proyecto Web simultaneamente. Para ello, se debe seleccionar ambos proyectos para ser ejecutados en las propiedades de la solución.

## Migraciones:
Para ejecutar las migraciones por linea de comando, es necesario tener instalado el modulo de entity framework de la linea de comando `dotnet`.  
Para ello, ejecute el siguiente comando:  
```dotnet tool install --global dotnet-ef```

Comandos:
```
Crear migracion: dotnet ef migrations add <NAME> --project ./GaleriaDavinci.Domain/ --startup-project .\GaleriaDavinci.Web\
Ejecutar migraciones: dotnet ef database update --startup-project .\GaleriaDavinci.Web\
Revertir migraciones: dotnet ef database update <nueva cabeza de migracion> --startup-project .\GaleriaDavinci.Web\
```
