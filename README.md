# Galeria Davinci
<img width="300" src="https://www.udla.edu.ec/clubes/wp-content/uploads/2021/07/udla_logo_blanco.png" />

### Materia: Programación IV
### Integrantes: Francisco Basantes, José I. Escudero, Christian Samaniego

## Descripción
La galería de arte DaVinci busca digitalizar su negocio para tener un mayor alcance. Para ello se requiere desarrollar una página web en la cual los visitantes puedan tener una vista general de todas las obras que disponen en el momento. Dicha página web debe mostrar las obras de arte que se encuentren en una base de datos, y debe permitir al usuario hacer clic en ella para ver más detalles.

El alcance del proyecto incluye el desarrollo de una página web en tecnologías .NET utilizando el patrón MVC. El proyecto inicialmente permitirá la autenticación de autores de obra de arte con el objetivo de que puedan gestionar las obras que se mostraran en la galería. Además de ello, permitirá a los otros usuarios dejar una calificación a las obras de arte en la galería. Posteriormente, se desarrollara una aplicación para escritorio utilizando la tecnología UWP y una aplicación móvil utilizando Xamarin que brindara las mismas funcionalidades que la aplicación web


## Requerimientos:
- .NET 5.
- Microsoft SQL Server

## Instrucciones:
- Instalar paquetes NuGet (Visual Studio 2019 lo hace automaticamente)
- Ejecutar migraciones (en caso de hacerlo por linea de comando, revisar la seccion de "Migraciones" abajo)
- Configurar la conexion a la base de datos (ConnectionString) en `appsettings.json`.
- Ejecutar proyecto en modo Kestrel (.exe) o utilizando IIS.

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
