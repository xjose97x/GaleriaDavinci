Crear migracion: dotnet ef migrations add <NAME> --project ./GaleriaDavinci.Domain/ --startup-project .\GaleriaDavinci.Web\
Ejecutar migraciones: dotnet ef database update --startup-project .\GaleriaDavinci.Web\
Revertir migraciones: dotnet ef database update <nueva cabeza de migracion> --startup-project .\GaleriaDavinci.Web\