SistemaCrud — ASP.NET Core MVC

App MVC con Login/Registro por cookies (sin Identity) y CRUD de Materias protegido.
Contraseñas con salt + hash y rutas seguras mediante autorización.

🧭 Índice

Resumen

Demo / Capturas

Tecnologías

Requisitos

Configuración

Ejecución

Uso

Arquitectura mínima

Estructura del repositorio

Notas de seguridad

Roadmap

Contribuir

Autor y licencia

✨ Resumen

Login/Registro implementado a mano con cookies + claims.

Sin Identity: control total y código simple de aprendizaje.

CRUD de Materias (crear, listar, editar, detalles y eliminar).

Rutas protegidas: sin sesión, el sistema redirige a /Auth/Login.

🖼️ Demo / Capturas

Coloca aquí tu GIF/imagen (o elimina esta sección si no lo usarás).

docs/
 ├─ demo.gif
 ├─ login.png
 ├─ materias-index.png
 └─ materias-create.png

![Demo](docs/demo.gif)

🧰 Tecnologías

ASP.NET Core MVC (.NET 8)

Entity Framework Core (migraciones y DbContext)

Bootstrap 5 (estilos)

SQL Server (LocalDB/SQLEXPRESS o instancia propia)

📦 Requisitos

.NET 8 SDK

SQL Server (o LocalDB / SQLEXPRESS)

(Opcional) Visual Studio 2022 / VS Code

⚙️ Configuración

Clonar

git clone https://github.com/TU_USUARIO/SistemaCrud.git
cd SistemaCrud


Crear tu appsettings.json
Copia la plantilla y edita la cadena de conexión:

SistemaCrud/appsettings.example.json → SistemaCrud/appsettings.json


Migraciones / Base de datos
Crea las tablas con EF Core:

# Visual Studio: Package Manager Console
Update-Database

# o CLI (si usas dotnet-ef)
dotnet ef database update --project SistemaCrud/SistemaCrud.csproj

▶️ Ejecución
dotnet run --project SistemaCrud/SistemaCrud.csproj
# Abre el navegador en https://localhost:xxxx

👩‍💻 Uso

Registro: /Auth/Register

Login: /Auth/Login

CRUD protegido: /Materias

Logout: botón “Salir” (navbar)

Si intentas /Materias sin sesión, el sistema te enviará a /Auth/Login.

🧱 Arquitectura mínima
Navegador
   │
   ├── Cookies de autenticación (sesión del usuario)
   │
ASP.NET Core MVC
   ├── AuthController   → Registro, Login, Logout (cookies + claims)
   ├── MateriasController [Authorize] → CRUD protegido
   ├── Views (Razor)    → Auth/*, Materias/*, Shared/*
   └── ApplicationDbContext (EF Core) → Usuarios, Materias

📁 Estructura del repositorio
SistemaCrud/
├─ SistemaCrud.sln
└─ SistemaCrud/
   ├─ Controllers/
   │  ├─ AuthController.cs          # Login/Registro/Logout (cookies)
   │  └─ MateriasController.cs      # CRUD completo protegido
   ├─ Models/
   │  ├─ Usuario.cs                 # Email, PasswordHash, PasswordSalt, FechaRegistro
   │  └─ Materia.cs                 # Nombre, Descripcion
   ├─ Data/
   │  └─ ApplicationDbContext.cs    # DbSet<Usuario>, DbSet<Materia>
   ├─ Security/
   │  └─ PasswordHasher.cs          # salt + hash (SHA-256)
   ├─ Views/
   │  ├─ Auth/ (Login, Register)
   │  ├─ Materias/ (Index, Create, Edit, Details, Delete)
   │  └─ Shared/ (_Layout, _Alerts, _ValidationScriptsPartial)
   ├─ wwwroot/                      # CSS/JS/Bootstrap
   ├─ Migrations/                   # EF Core migrations
   ├─ appsettings.example.json
   └─ Program.cs

🔒 Notas de seguridad

No se guardan contraseñas en texto plano: se usa salt + hash.

Para producción, considera PBKDF2 / BCrypt / Argon2 y HTTPS.

appsettings.json no se versiona; usa la plantilla appsettings.example.json.

🗺️ Roadmap

 Asociar materias por usuario (multiusuario real).

 Paginación y filtros en el listado de materias.

 Validaciones adicionales y mensajes localizados.

 Cambiar hashing a PBKDF2/BCrypt/Argon2.

🤝 Contribuir

Haz fork del proyecto.

Crea una rama: git checkout -b feature/nueva-funcionalidad.

Commit: git commit -m "feat: agrega X".

Push: git push origin feature/nueva-funcionalidad.

Abre un Pull Request.

👤 Autor y licencia

Autor: Tu Nombre — @tuusuario

Licencia: MIT (ver LICENSE)
