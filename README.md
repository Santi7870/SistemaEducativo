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


VIDEO

https://youtu.be/TfqdsGl-c2E

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

git clone https://github.com/Santi7870/SistemaEducativo.git
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

👤 Autor

Autor: Santiago Panchi

Ingenieria de Software
