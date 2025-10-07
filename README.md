SistemaCrud (ASP.NET Core MVC)
<p align="left"> <img src="https://img.shields.io/badge/STATUS-Listo-2ea44f" alt="Status"> <img src="https://img.shields.io/badge/.NET-8.0-512BD4" alt=".NET 8"> <img src="https://img.shields.io/badge/ORM-EF%20Core-6db33f" alt="EF Core"> <img src="https://img.shields.io/badge/Licencia-MIT-blue" alt="MIT"> </p>

App MVC con Login/Registro (cookies) y CRUD de Materias protegido.
Autenticación implementada manualmente (sin Identity): hash + salt de contraseñas y rutas seguras.

Índice

Descripción

Demo / Capturas

Estado del proyecto

Tecnologías

Requisitos

Configuración y ejecución

Estructura del proyecto

Uso

Roadmap

Contribuir

Autores

Licencia



Descripción

SistemaCrud es una app educativa de ejemplo construida con ASP.NET Core MVC.
Incluye:

Registro e inicio de sesión con cookies y claims (sin usar Identity).

Almacenamiento seguro de contraseñas con salt + hash.

Protección de rutas: el CRUD de materias solo es accesible estando autenticado.

CRUD completo de Materias: crear, listar, editar, ver y eliminar.

Demo / Capturas

GIF corto del flujo: Login → acceso a /Materias → Crear/Editar/Eliminar → Logout
(Coloca aquí tu GIF/imagen, por ejemplo docs/demo.gif o docs/captura.png)



Incluir imágenes/gifs ayuda a entender las funcionalidades de forma visual. 
Alura

Estado del proyecto

✅ Listo para uso y revisión (demo universitaria).

Incluir el estado es recomendado para lectores y reclutadores. 
Alura

Tecnologías

.NET 8 + ASP.NET Core MVC

Entity Framework Core

Bootstrap 5

SQL Server

Listar tecnologías es una forma clara de mostrar qué usaste/estudiaste. 
Alura

Requisitos

.NET 8 SDK

SQL Server (LocalDB/SQLEXPRESS o instancia propia)

(Opcional) Visual Studio 2022 / VS Code

Configuración y ejecución

Clonar el repo

git clone https://github.com/TU_USUARIO/SistemaCrud.git
cd SistemaCrud


Crear tu appsettings.json (no se versiona):

Copia la plantilla:

SistemaCrud/appsettings.example.json → SistemaCrud/appsettings.json

Edita la cadena de conexión DefaultConnection.

Crear la base de datos con EF Core

# Visual Studio - Package Manager Console:
Update-Database

# (CLI alternativo)
dotnet ef database update --project SistemaCrud/SistemaCrud.csproj

Imagenes

<img width="1327" height="718" alt="image" src="https://github.com/user-attachments/assets/2dcf5029-82d4-4029-82f0-2c50ba395c04" />

<img width="902" height="442" alt="image" src="https://github.com/user-attachments/assets/706722f3-93d8-4f75-b257-613db0d60e7b" />

Ejecutar

dotnet run --project SistemaCrud/SistemaCrud.csproj
# Abre https://localhost:xxxx


La sección de “Acceso/Ejecución” es clave: explica cómo descargar, abrir y correr el proyecto localmente. 
Alura

Estructura del proyecto
SistemaCrud/
├─ SistemaCrud.sln
└─ SistemaCrud/
   ├─ Controllers/
   │  ├─ AuthController.cs         # Login / Register / Logout (cookies)
   │  └─ MateriasController.cs     # CRUD protegido
   ├─ Models/
   │  ├─ Usuario.cs                # Email, PasswordHash, PasswordSalt
   │  └─ Materia.cs                # Nombre, Descripcion
   ├─ Data/
   │  └─ ApplicationDbContext.cs   # DbSet<Usuario>, DbSet<Materia>
   ├─ Security/
   │  └─ PasswordHasher.cs         # salt + hash (SHA-256)
   ├─ Views/
   │  ├─ Auth/ (Login, Register)
   │  ├─ Materias/ (Index, Create, Edit, Details, Delete)
   │  └─ Shared/ (_Layout, _ValidationScriptsPartial, _Alerts)
   ├─ wwwroot/                     # CSS/JS/Bootstrap
   ├─ appsettings.example.json
   └─ Program.cs

Uso

Ir a /Auth/Register y crear una cuenta.

Iniciar sesión en /Auth/Login.

Acceder a /Materias y usar el CRUD.

Cerrar sesión con el botón Salir.

(Prueba de protección) Sin sesión, entrar a /Materias → redirige a /Auth/Login.
