

# Instrucciones de Configuración y Ejecución del Proyecto

## Configuración de Variables de Entorno

Antes de ejecutar el API, es necesario configurar las variables de entorno. Estas variables son esenciales para conectar con las bases de datos y configurar aspectos de seguridad y servicios de correo electrónico.

Configuración de Conexiones a Bases de Datos

```
# Para Windows:
setx ConnectionStrings__SimetricaConsultingConnection "tu_cadena_de_conexion_aqui"
setx ConnectionStrings__SimetricaConsultingIdentityConnection "tu_cadena_de_conexion_de_identidad_aqui"
setx ConnectionStrings__SimetricaConsultingAuditConnection "tu_cadena_de_conexion_de_auditoria_aqui"
```

## Configuración de JWT para Identity

```
setx JwtSettings__Key "your-32-character-long-secret-key"
setx JwtSettings__Issuer "your-issuer"
setx JwtSettings__Audience "your-audience"
setx JwtSettings__EmailConfirmationTokenDurationInHours "24"  # Ejemplo: token válido por 24 horas
setx JwtSettings__PasswordResetTokenDurationInMinutes "120"  # Ejemplo: token válido por 120 minutos
setx JwtSettings__LoginTokenDurationInMinutes "60"  # Ejemplo: token válido por 60 minutos
setx JwtSettings__ChangeEmailTokenDurationInMinutes "30"  # Ejemplo: token válido por 30 minutos
```

## Configuración del Servicio de Email

```
setx MailSettings__EmailFrom "your-email@example.com"
setx MailSettings__SmtpHost "smtp.example.com"
setx MailSettings__SmtpPort "587"  # Ejemplo: puerto para SMTP
setx MailSettings__SmtpUser "your-smtp-username"
setx MailSettings__SmtpPass "your-smtp-password"
setx MailSettings__DisplayName "Your Display Name"
```

## Migraciones y Actualización de Bases de Datos

Navega al directorio `src` y ejecuta los siguientes comandos en la línea de comando para gestionar las migraciones y actualizar las bases de datos para diferentes contextos.

### Migraciones para ApplicationDbContext

```
dotnet ef migrations add Initial --project src\Infrastructure\SimetricaConsulting.Intrastructure.Persistence\SimetricaConsulting.Persistence.csproj --startup-project src\Presentation\SimetricaConsulting.API\SimetricaConsulting.API.csproj --context ApplicationDbContext
dotnet ef database update --project src\Infrastructure\SimetricaConsulting.Intrastructure.Persistence\SimetricaConsulting.Persistence.csproj --startup-project src\Presentation\SimetricaConsulting.API\SimetricaConsulting.API.csproj --context ApplicationDbContext
```

### Migraciones para AuditDbContext

```bash
dotnet ef migrations add Initial --project src\Infrastructure\SimetricaConsulting.Intrastructure.Persistence\SimetricaConsulting.Persistence.csproj --startup-project src\Presentation\SimetricaConsulting.API\SimetricaConsulting.API.csproj --context AuditDbContext
dotnet ef database update --project src\Infrastructure\SimetricaConsulting.Intrastructure.Persistence\SimetricaConsulting.Persistence.csproj --startup-project src\Presentation\SimetricaConsulting.API\SimetricaConsulting.API.csproj --context AuditDbContext
```

### Migraciones para IdentityContext

```
dotnet ef migrations add Initial --project src\Infrastructure\SimetricaConsulting.Intrastructure.Identity\SimetricaConsulting.Identity.csproj --startup-project src\Presentation\SimetricaConsulting.API\SimetricaConsulting.API.csproj --context IdentityContext
dotnet ef database update --project src\Infrastructure\SimetricaConsulting.Intrastructure.Identity\SimetricaConsulting.Identity.csproj --startup-project src\Presentation\SimetricaConsulting.API\SimetricaConsulting.API.csproj --context IdentityContext
```

Una vez completados estos pasos, el API estará listo para ser ejecutado.

### Usuarios Creados al Migrar las Bases de Datos

Al ejecutar las migraciones, se crean dos usuarios por defecto:

- **Admin:**
  - Email: johnDoe@gmail.com
  - Contraseña: 123Pa$$word

- **Usuario Normal:**
  - Email: johnJames@gmail.com
  - Contraseña: 123Pa$$word

## Ejecución del Frontend de Angular

Para ejecutar el frontend desarrollado con Angular, sigue estos pasos:

1. Navega al directorio `src\Presentation\SimetricaConsulting.Web`.
2. Ejecuta en la línea de comando `npm i` para instalar las dependencias.
3. Una vez instaladas las dependencias, ejecuta `ng serve -o` para iniciar el servidor de desarrollo y abrir la aplicación en el navegador.

Con estos pasos, tanto el backend como el frontend deberían estar funcionando correctamente.

## Ejecución de Tests

### Tests en Angular con Jest

Para ejecutar los tests en el proyecto Angular utilizando Jest, sigue estos pasos:

1. Navega al directorio del proyecto Angular, por ejemplo, `src\Presentation\SimetricaConsulting.Web`.
2. Asegúrate de tener Jest instalado. Si no lo tienes, puedes instalarlo ejecutando `npm install jest jest-preset-angular --save-dev`.
3. Ejecuta los tests con el siguiente comando:

```
npm test
```

### Tests en .NET con NUnit

Para ejecutar los tests en el proyecto .NET utilizando NUnit, sigue estos pasos:

1. Navega al directorio del proyecto de tests .NET.
2. Ejecuta el siguiente comando para ejecutar los tests:

```
dotnet test
```

Estos comandos ejecutarán todos los tests configurados en los proyectos respectivos.
#
