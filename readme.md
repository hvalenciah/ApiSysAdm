# ADP.API Manual de Uso

Este manual muestra la estrucutra de directorios y archivo, describe pasos necesarios para realizar el scaffolding de la base de datos, configurar el entorno de ejecución y compilar el proyecto ADP.API.

## Estructura de directorios y archivos

ADP.API.sln
│
├── ADP.API.Api/ → Proyecto Web API (punto de entrada y capa de presentación)
│ ├── Controllers/ → Contiene los controladores que exponen los endpoints HTTP.
│ │ ├── UsuarioController.cs
│ ├── Middlewares/ → Middleware personalizados (manejo de excepciones, logging, autenticación, etc.).
│ │ ├── AuthMiddleware.cs
│ ├── Program.cs → Punto de entrada de la aplicación y configuración inicial.
│ ├── appsettings.Development.json → Configuración específica para el entorno de desarrollo (DEV).
│ ├── appsettings.Quality.json → Configuración para el entorno de pruebas de calidad (QA).
│ ├── appsettings.Production.json → Configuración para el entorno de producción (PRO).
│ ├── Properties/
│ │ ├── launchSettings.json → Define los perfiles de ejecución y configuración de entorno local.
│
├── ADP.API.Model/ → Capa de acceso a datos y entidades del dominio
│ ├── Data/ → Contiene el `DbContext` y configuración de EF Core (migraciones, conexiones).
│ │ ├── DbContext.cs → Clase principal de EF Core que representa la sesión con la base de datos.
│ ├── Entities/ → Entidades del dominio que representan las tablas y reglas del negocio.
│ │ ├── Usuario.cs
│ ├── Models/ → Modelos personalizados (por ejemplo, modelos para peticiones/respuestas, validaciones, etc.).
│ │ ├── RespuestaModel.cs
│
├── ADP.API.Service/ → Capa de lógica de negocio (servicios de aplicación)
│ ├── DTOs/ → Objetos de transferencia de datos entre capas (evitan exponer directamente las entidades).
│ │ ├── UsuarioDTO.cs
│ ├── Helpers/ → Funciones auxiliares, constantes, extensiones, utilidades comunes.
│ │ ├── EncriptacionHelper.cs
│ ├── Interfaces/ → Contratos que definen qué servicios deben implementar (como IProductService, IEmailService).
│ │ ├── IUsuario.cs
│ ├── Mappings/ → Configuración de AutoMapper (mapeo entre entidades y DTOs).
│ │ ├── UsuarioMapping.cs
│ ├── Services/ → Implementaciones concretas de la lógica de negocio (ProductService, AuthService, etc.).
│ │ ├── Usuario.cs
│
├── Readme.md → Documentación general del proyecto, cómo ejecutarlo, estructura, etc.

## Scaffolding de la Base de Datos

### Paso 1: Configurar la cadena de conexión

Edita el archivo `appsettings.json` para incluir la cadena de conexión a la base de datos:

```json
{
  "ConnectionStrings": {
    "BalcanDb": "Server=; Database=; User Id=; Password=; Trusted_Connection=True;"
  }
}
```

### Paso 2: Ejecutar el comando de scaffolding

Desde la terminal, ejecuta el siguiente comando para generar las entidades y el contexto desde la base de datos:

```bash
dotnet ef dbcontext scaffold "Name=BalcanDb" Microsoft.EntityFrameworkCore.SqlServer --project ADP.API.Model --output-dir Entities --context-dir Data --context DbContext --namespace ADP.API.Model.Entities --context-namespace ADP.API.Model.Data --force

dotnet ef dbcontext scaffold "Server=localhost;Database=Balcan;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities --context BalcanContext --table CDP.INFO_PLAZAS_COMPAQ --table CDP.INFO_PLAZAS_COMPAQ_AUX --table CDP.HISTORICO_CAMBIOS --force
```

## Configuración del Entorno y Depuración

### Modificar el entorno de ejecución

Edita el archivo launchSettings.json ubicado dentro de la carpeta Properties del proyecto ADP.API.Api. Cambia el valor de ASPNETCORE_ENVIRONMENT según el entorno deseado: Development, Quality, o Production.

```json
{
  "profiles": {
    "ADP.API.Api": {
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

### Ejecutar el proyecto

Compila y ejecuta el proyecto localmente con:

```bash
dotnet run
```

## Compilación del Proyecto

### Preparar el entorno

Verifica nuevamente que el archivo launchSettings.json esté configurado correctamente con el entorno deseado.

### Publicar la aplicación

Ejecuta el siguiente comando para compilar y publicar el proyecto:

```bash
dotnet publish -c Release --self-contained --output "C:\"
```

Para agregar el entorno al web.config, solo tienes que incluir el nodo <environmentVariables> dentro de <aspNetCore> así

```xml
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath=".\ADP.API.Api.exe" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess">
        <environmentVariables>
          <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Production" />
        </environmentVariables>
      </aspNetCore>
    </system.webServer>
  </location>
</configuration>
```
